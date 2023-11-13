namespace Academic_Blog.PayLoad.Request.Report
{
    public class AddReportRequest
    {
        public string Content { get; set; } = null!;
        public Guid CommentId { get; set; }
    }
}
