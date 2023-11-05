using Academic_Blog.Domain.Models;
using Academic_Blog.Enums;
using Academic_Blog.PayLoad.Request.Blog;
using Academic_Blog.Utils;
using Academic_Blog_App.Services.ClientEnum;
using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Academic_Blog_App.Pages.LecturePage
{
    public class ReviewPostDetailModel : PageModel
    {
        private readonly ApiHelper _apiHelper;
        [BindProperty]
        public Blog Blog { get; set; } = default!;

        public ReviewPostDetailModel(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        private async  Task FetchData(string? blogId)
        {
            var result = await _apiHelper.FetchODataAsync<List<Blog>>(Services.ClientEnum.EndPointEnum.Blogs, $"?$filter=id eq {Guid.Parse(blogId!)}&$expand=Author");
            if (result.IsSuccess)
            {
                Blog = result.Data[0];
            }
        }
        public async Task<IActionResult> OnGetAsync(string? blogId)
        {
            
            if (blogId == null)
            {
                return RedirectToPage("/Index");
            }
            await FetchData(blogId);
            
            return Page();
        }
        public async Task<IActionResult> OnPostApprove()
        {
            CensorBlogRequest request = new CensorBlogRequest
            {
                Status = BlogStatus.APPROVED.GetDescriptionFromEnum<BlogStatus>(),
                ReviewFromReviewer = Blog.ReviewFromReviewer
            };
             var result = await _apiHelper.FetchApiAsync<string>(Services.ClientEnum.EndPointEnum.Blogs, $"/{Blog.Id}/censor", MethodEnum.PUT, request);
            if (result.IsSuccess)
            {
                return RedirectToPage("/LecturePage/ReviewPost");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostReject()
        {

            CensorBlogRequest request = new CensorBlogRequest
            {
                Status = BlogStatus.REJECTED.GetDescriptionFromEnum<BlogStatus>(),
                ReviewFromReviewer = Blog.ReviewFromReviewer
            };
            var result = await _apiHelper.FetchApiAsync<string>(Services.ClientEnum.EndPointEnum.Blogs, $"/{Blog.Id}/censor", MethodEnum.PUT, request);
            if (result.IsSuccess)
            {
                return RedirectToPage("/LecturePage/ReviewPost");
            }
            return Page();
        }
    }
}
