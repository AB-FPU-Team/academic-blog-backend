using Academic_Blog.Domain.Models;

namespace Academic_Blog.Services.Interfaces
{
    public interface IReportService
    {
        Task<List<Report>> GetReports();
    }
}
