using Academic_Blog.Domain;
using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Request.Report;
using Academic_Blog.Repository.Interfaces;
using Academic_Blog.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Academic_Blog.Services.Implements
{
    public class ReportService : BaseService<ReportService>, IReportService
    {
        public ReportService(IUnitOfWork<AcademicBlogContext> unitOfWork, ILogger<ReportService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {

        }

        public async Task<bool> CreateReport(AddReportRequest reportRequest)
        {
          Report report = _mapper.Map<Report>(reportRequest);
          report.Id = Guid.NewGuid();
          await _unitOfWork.GetRepository<Report>().InsertAsync(report);
          bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
          return isSuccessful;
        }

        public async Task<List<Report>> GetReports()
        {
            ICollection<Report> reports = await _unitOfWork.GetRepository<Report>().GetListAsync(predicate: x => x.Id == x.Id,include: x => x.Include(x => x.Comment));
            List<Report> result = reports.ToList();
            return result;
        }
    }
}
