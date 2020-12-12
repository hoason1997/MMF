using AutoMapper;
using AutoMapper.QueryableExtensions;
using MFF.DTO.BaseEntities;
using MFF.DTO.Constants;
using MFF.DTO.Enums;
using MFF.DTO.Helpers;
using MFF.Infrastructure.Mapping;
using MFF.Infrastructure.Models;
using MFF.Infrastructure.Repositories;
using MFF.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public class RoleService : Service, IRoleService
    {
        private readonly IRepository<UserRole> userRoleRepo;
        private readonly IRepository<Role> roleRepo;
        private readonly IRepository<RolePermission> rolePermissionRepo;
        private readonly IRepository<User> userRepo;
        public RoleService(IUnitOfWork unitOfWork
            , IMapper mapper
            , IRedisCacheService redisCache
            , IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, redisCache, httpContextAccessor)
        {
            userRoleRepo = unitOfWork.Repository<UserRole>();
            roleRepo = unitOfWork.Repository<Role>();
            rolePermissionRepo = unitOfWork.Repository<RolePermission>();
            userRepo = unitOfWork.Repository<User>();
        }

        public async Task InitRoles()
        {
            var strRoles = Enum.GetNames(typeof(SystemRole)).ToList();
            if (strRoles != null && strRoles.Count() > 0)
            {
                var admin = await userRepo.Query(x => x.Username == Constant.ADMIN_USERNAME).FirstOrDefaultAsync();
                foreach (var item in strRoles)
                {
                    var role = await roleRepo.Query(x => x.Name == item).FirstOrDefaultAsync();
                    if (role == null)
                    {
                        role = new Role
                        {
                            Name = item,
                            Description = "Default role for admin",
                            CreatedBy = admin == null ? string.Empty : admin.Id,
                            UpdatedBy = admin == null ? string.Empty : admin.Id,
                            CreatedTime = DateTime.UtcNow,
                            UpdatedTime = DateTime.UtcNow
                        };

                        await roleRepo.AddAsync(role);
                        await unitOfWork.SaveChangesAsync();
                    }
                }
            }
        }
                
        public async Task<IEnumerable<RoleItemModel>> GetAll()
        {
            var configuration = new MapperConfiguration(cfg => new RoleProfile());

            return await roleRepo.Query().ProjectTo<RoleItemModel>(configuration).ToListAsync();// .ToListAsync();
        }

        public async Task<IEnumerable<RoleItemModel>> GetByUser(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var userRoles = await userRoleRepo.Query(x => x.UserId == userId)
                    .Include(x => x.Role)
                    .ToListAsync();
                if (userRoles != null && userRoles.Any())
                {
                    var roles = userRoles.Select(x => mapper.Map<RoleItemModel>(x.Role));
                    return roles;
                }
            }

            return null;
        }

        public async Task<bool> CheckHasPermission(string userId, string[] inputPermissions)
        {
            var userPermissions = await GetPermissionsByUser(userId);
            if (userPermissions != null && userPermissions.Any())
            {
                var intersect = inputPermissions.Intersect(userPermissions);
                if (intersect.Any())
                    return true;
            }
            return false;
        }

        public async Task<IEnumerable<string>> GetPermissionsByUser(string userId)
        {
            var userRoles = await userRoleRepo.Query(x => x.UserId == userId)
                .Include(x => x.Role)
                .ThenInclude(x => x.Permissions)
                .ToListAsync();
            if (userRoles != null && userRoles.Any())
            {
                var rolePermissions = userRoles.SelectMany(x => x.Role.Permissions).Select(x => x.Permission);
                return rolePermissions;
            }

            return null;
        }

        public async Task InitAdministrationPermissions()
        {
            var admin = await userRepo.Query(x => x.Username == Constant.ADMIN_USERNAME).FirstOrDefaultAsync();
            var adminRole = await roleRepo.Query(x => x.Name == SystemRole.Administrator.ToString())
                .Include(x => x.Permissions)
                .FirstOrDefaultAsync();
            if (adminRole != null)
            {
                var permissionsAdd = new List<RolePermission>();
                var permissions = PermissionDisplay<Permissions>.GetPermissionsToDisplay(typeof(Permissions));

                foreach (var per in permissions)
                {
                    var isExist = adminRole.Permissions.Any(x => x.Permission == per.PermissionName);
                    if (!isExist)
                    {
                        permissionsAdd.Add(new RolePermission
                        {
                            RoleId = adminRole.Id,
                            Permission = per.PermissionName,
                            CreatedBy = admin == null ? string.Empty : admin.Id,
                            UpdatedBy = admin == null ? string.Empty : admin.Id,
                            CreatedTime = DateTime.UtcNow,
                            UpdatedTime = DateTime.UtcNow
                        });
                    }
                }

                if (permissionsAdd.Any())
                {
                    await rolePermissionRepo.AddAsync(permissionsAdd);
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }

        public async Task InitAdminRoles()
        {
            var adminRole = await roleRepo.Query(x => x.Name == SystemRole.Administrator.ToString()).FirstOrDefaultAsync();
            if (adminRole != null)
            {
                var admin = await userRepo.Query(x => x.Username == Constant.ADMIN_USERNAME).FirstOrDefaultAsync();
                if (admin != null)
                {
                    var isExists = await userRoleRepo.CheckExistsAsync(x => x.UserId == admin.Id && x.RoleId == adminRole.Id);
                    if (!isExists)
                    {
                        var userRole = new UserRole
                        {
                            UserId = admin.Id,
                            RoleId = adminRole.Id,
                            CreatedBy = admin.Id,
                            UpdatedBy = admin.Id,
                            CreatedTime = DateTime.UtcNow,
                            UpdatedTime = DateTime.UtcNow,
                        };

                        await userRoleRepo.AddAsync(userRole);
                        await unitOfWork.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
