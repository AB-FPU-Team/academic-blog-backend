using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Request.Report;
using AutoMapper;

namespace Academic_Blog.Mappers.Reports
{
    public class ReportMapper : Profile
    {
        public ReportMapper()
        {
            CreateMap<AddReportRequest, Report>();
        }
    }
}
