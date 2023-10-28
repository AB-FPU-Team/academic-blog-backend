using Academic_Blog.Domain;
using Academic_Blog.Domain.Models;
using Academic_Blog.Repository.Interfaces;
using Academic_Blog.Services.Interfaces;
using AutoMapper;

namespace Academic_Blog.Services.Implements
{
    public class ReportService : BaseService<ReportService>, IReportService
    {
        public ReportService(IUnitOfWork<AcademicBlogContext> unitOfWork, ILogger<ReportService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {

        }

        public async Task<List<Report>> GetReports()
        {
            ICollection<Report> reports = await _unitOfWork.GetRepository<Report>().GetListAsync(predicate: x => x.Id == x.Id);
            List<Report> result = reports.ToList();
            return result;
        }
    }
}
