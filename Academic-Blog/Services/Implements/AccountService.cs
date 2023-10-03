using Academic_Blog.Domain;
using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Request;
using Academic_Blog.PayLoad.Response;
using Academic_Blog.Repository.Interfaces;
using Academic_Blog.Services.Interfaces;
using Academic_Blog.Utils;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academic_Blog.Services.Implements
{
    public class AccountService : BaseService<AccountService>, IAccountService
    {
        public AccountService(IUnitOfWork<AcademicBlogContext> unitOfWork, ILogger<AccountService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            Expression<Func<Account, bool>> accountFilter = p =>
                 p.UserName.Equals(loginRequest.Username) &&
                 p.Password.Equals(loginRequest.Password);
            Account account = await _unitOfWork.GetRepository<Account>().SingleOrDefaultAsync(predicate: accountFilter,include : p => p.Include(x => x.Role));
            if(account == null)
            {
                return null;
            }
            string Role = account.Role.Name;
            Tuple<string, Guid> guidClaim = new Tuple<string,Guid>("userId",account.Id);
            var token = JwtUtil.GenerateJwtToken(account, guidClaim);
            LoginResponse loginResponse = new LoginResponse
            {
                AccessToken = token,
                Id = account.Id,
                Username = account.UserName,
                Name = account.Name,
                Role = Role,
                AccountStatus = account.Status,
            };
           return loginResponse;
        }
    }
}
