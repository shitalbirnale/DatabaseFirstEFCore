using DatabaseFirstEFCore.Model;

namespace DatabaseFirstEFCore.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LogIn(LoginDTO userDetails);
    }
}
