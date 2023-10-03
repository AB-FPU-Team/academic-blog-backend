using Academic_Blog.PayLoad.Request;
using Academic_Blog.PayLoad.Response;

namespace Academic_Blog.Services.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
