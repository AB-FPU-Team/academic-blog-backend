using Academic_Blog.Domain.Models;
using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Academic_Blog_App.Services.ClientEnum;
using System.Text.Json;
using Academic_Blog_App.Services.ClientAjax;

namespace Academic_Blog_App.Pages.BlogPage
{
    public class ViewBlogDetailModel : PageModel
    {
        private readonly ApiHelper _apiHelper;
        private readonly CenterHub _centerHub;
        public ViewBlogDetailModel(ApiHelper apiHelper, CenterHub centerHub)
        {
            _apiHelper = apiHelper;
            _centerHub = centerHub;
        }

        [BindProperty]
        public Blog Blog { get; set; } = default!;
        public Account Account { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(string? blogId, string? authorId)
        {
            if (blogId == null || authorId == null)
            {
                return RedirectToPage("/Index");
            }
            await FetchAll(blogId, authorId);
            await _centerHub.TrackPost(blogId);
            return Page();
        }

        private async Task<IActionResult> FetchAll(string? blogId, string? authorId)
        {
            var blogResult = await _apiHelper.FetchApiAsync<Blog>(EndPointEnum.Blogs, $"/{Guid.Parse(blogId!)}", MethodEnum.GET, null);
            var accountResult = await _apiHelper.FetchApiAsync<Account>(EndPointEnum.Accounts, $"?$filter=id eq {authorId}", MethodEnum.GET, null);

            if(blogResult.IsSuccess && accountResult.IsSuccess)
            {
                Blog = blogResult.Data;
                Account = accountResult.Data;
            }
            else
            {
                TempData["Error"] = blogResult.ErrorMessage + "/n" + accountResult.ErrorMessage;
                TempData["PageName"] = "ViewBlogDetails";
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}
