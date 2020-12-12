using AutoMapper;
using MFF.DTO.BaseEntities;
using MFF.DTO.Constants;
using MFF.DTO.Helpers;
using MFF.DTO.Settings;
using MFF.Infrastructure.Models;
using MFF.Infrastructure.Repositories;
using MFF.Infrastructure.UnitOfWork;
using MFF.Infrastructure.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public class AccountService : Service, IAccountService
    {
        private readonly AuthSetting authSetting;
        private readonly ResetPasswordSetting resetPasswordSetting;
        private readonly int tokenExpiredInDay;
        private readonly IRepository<User> userRepo;
        private readonly IFileService fileService;
        private readonly IRoleService roleService;

        public AccountService(IUnitOfWork unitOfWork
            , IMapper mapper
            , IRedisCacheService redisCache
            , IHttpContextAccessor httpContextAccessor
            , IOptions<AuthSetting> authSetting
            , IOptions<ResetPasswordSetting> resetPasswordSetting
            , IFileService fileService
            , IRoleService roleService   )
            : base(unitOfWork, mapper, redisCache, httpContextAccessor)
        {
            userRepo = unitOfWork.Repository<User>();
            tokenExpiredInDay = 15;
            this.authSetting = authSetting.Value;
            this.roleService = roleService;
            this.resetPasswordSetting = resetPasswordSetting.Value;
            this.fileService = fileService;
        }

        public async Task ResetPassword(ResetPasswordModel model)
        {
            if (model == null)
                throw new ArgumentException(MessageConstant.RESET_PASSWORD_FAILED);

            var payload = EncryptHelper.Decrypt<ResetPasswordPayload>(model.Token);
            if (payload == null)
                throw new ArgumentException(MessageConstant.RESET_PASSWORD_FAILED);

            var utcNow = DateTime.UtcNow;
            if (utcNow.AddMinutes(resetPasswordSetting.LinkExpiredInMinutes) < utcNow)
                throw new ArgumentException(MessageConstant.RESET_PASSWORD_TOKEN_EXPIRED);

            var user = await userRepo.Query(x => x.Id == payload.UserId).FirstOrDefaultAsync();
            if (user == null)
                throw new ArgumentException(MessageConstant.RESET_PASSWORD_FAILED);

            user.PasswordHash = PasswordHelper.HashPassword(model.Password);
            userRepo.Update(user);
            var result = await unitOfWork.SaveChangesAsync();
            if (result < 1)
                throw new ArgumentException(MessageConstant.RESET_PASSWORD_FAILED);
        }

        public async Task ForgotPassword(string email)
        {
            email = email.Trim().ToLower();
            var user = await userRepo.Query(x => x.Email == email).FirstOrDefaultAsync();
            if (user == null)
                throw new ArgumentException(MessageConstant.EMAIL_NOT_FOUND);

            var token = EncryptHelper.Encrypt(new ResetPasswordPayload { UserId = user.Id, DateUTC = DateTime.UtcNow.ToString() });
            var resetPasswordLink = $"{resetPasswordSetting.ResetPasswordLink}/{token}";
            var fullName = string.IsNullOrEmpty(user.MiddleName) ? $"{user.FirstName} {user.LastName}" : $"{user.FirstName} {user.MiddleName} {user.LastName}";

            var body = $"<div> Dear <span style ='color: #ff0000;'>{fullName}</span></div><br/>" +
                $"<div>You recently requested to reset your password for your MDS account. Please click on the link below to reset it.</div><br/>" +
                $"<div><a href ='{resetPasswordLink}'>Reset Password</a></div><br/>" +
                $"<div>This password reset is only valid for the next {resetPasswordSetting.LinkExpiredInMinutes} minutes</div><br/><p>Sincerely,<br/>MDS Team</p>";
            //await mailService.SendAsync(email
            //    , user.FirstName
            //    , "[Metronic Detailing Services - Portal] Forgot Password"
            //    , body);
        }

        public async Task<LoginSuccessModel> Login(LoginModel loginModel)
        {
            if (loginModel == null)
                throw new ArgumentException(MessageConstant.ACCOUNT_LOGIN_FAILED);

            loginModel.UserName = loginModel.UserName.Trim().ToLower();

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(loginModel.UserName);
            var user = new User();
            if (match.Success)
            {
                 user = await userRepo.Query(x => x.Email == loginModel.UserName).FirstOrDefaultAsync();
            }
            else
            {
                 user = await userRepo.Query(x => x.Username == loginModel.UserName).FirstOrDefaultAsync();
            }

            if (user == null)
                throw new ArgumentException(MessageConstant.ACCOUNT_LOGIN_FAILED);

            var checkPassword = PasswordHelper.VerifyHashedPassword(user.PasswordHash, loginModel.Password);
            if (!checkPassword)
                throw new ArgumentException(MessageConstant.ACCOUNT_LOGIN_FAILED);

            return await CreateLoginResponse(user);
        }

        private async Task<LoginSuccessModel> CreateLoginResponse(User user)
        {
            var profile = mapper.Map<UserProfileResponse>(user);
            profile.AvatarFullUrl = fileService.ToFullUrl(user.AvatarUrl);

            var roles = await roleService.GetByUser(user.Id);
            if (roles != null)
                profile.Roles = roles.Select(x => x.Name);
            profile.Permissions = await roleService.GetPermissionsByUser(user.Id);

            var result = new LoginSuccessModel
            {
                AccessToken = await GenerateJwtToken(user),
                TokenType = "Bearer",
                ExpiresIn = tokenExpiredInDay * 24 * 60 * 60,
                UserProfile = profile
            };

            return result;
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            if (user == null)
                return string.Empty;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var roles = await roleService.GetByUser(user.Id);
            if (roles != null && roles.Any())
                claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x.Name)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSetting.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(tokenExpiredInDay),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
