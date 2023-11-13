using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Request.Report;

namespace Academic_Blog.Services.Interfaces
{
    public interface IReportService
    {
        Task<List<Report>> GetReports();
        Task<bool> CreateReport(AddReportRequest reportRequest);
    }
}
