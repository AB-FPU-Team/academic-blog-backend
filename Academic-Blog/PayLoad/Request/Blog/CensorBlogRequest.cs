using System.ComponentModel.DataAnnotations;

namespace Academic_Blog.PayLoad.Request.Blog
{
    public class CensorBlogRequest
    {
        [Required(ErrorMessage ="Status is not missing")]
        public string Status { get; set; }

    }
}
