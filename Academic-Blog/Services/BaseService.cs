using Academic_Blog.Domain;
using Academic_Blog.Repository.Interfaces;
using AutoMapper;
using System.Security.Claims;

namespace Academic_Blog.Services
{
    public class BaseService<T> where T : class
    {
        protected IUnitOfWork<AcademicBlogContext> _unitOfWork;
        protected ILogger<T> _logger;
        protected IMapper _mapper;
        protected IHttpContextAccessor _httpContextAccessor;
        public BaseService(IUnitOfWork<AcademicBlogContext> unitOfWork, ILogger<T> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        protected string GetUserNameFromJwt()
        {
            string username = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return username;
        }
        protected string GetRoleFromJwt()
        {
            string role = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.Role);
            return role;
        }
        protected string GetUserIdFromJwt()
        {
            return _httpContextAccessor?.HttpContext?.User?.FindFirstValue("userId");
        }
    }
}
