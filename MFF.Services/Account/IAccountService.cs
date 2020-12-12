using MFF.Infrastructure.Models;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public interface IAccountService : IService
    {
        Task ResetPassword(ResetPasswordModel model);
        Task ForgotPassword(string email);
        Task<LoginSuccessModel> Login(LoginModel loginModel);
    }
}
