using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Response;
using Academic_Blog_App.Services.ClientEnum;
using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Academic_Blog_App.Pages.UserPage
{
    public class LectureProfileModel : PageModel
    {
        private readonly ApiHelper _apiHelper;
        public LectureProfileModel(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public LoginResponse CurrentAccount { get; set; }
        public List<Blog> Blogs { get; set; } = default!;
        public Account Account { get; set; } = default!;
        public int awardEarned = 0, totalViewed = 0, mostViewedBlog = 0, totalComment = 0, totalBlog = 0;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Index");
            }
          

            await FetchAll(id);
            return Page();
        }


        private async Task FetchAll(string? userId)
        {
            var accountResult = await _apiHelper.FetchODataAsync<List<Account>>(EndPointEnum.Accounts, $"?$filter=Id eq {Guid.Parse(userId)}");
            if (accountResult.IsSuccess)
            {
                Account = accountResult.Data[0];
                var result1 = await _apiHelper.FetchApiAsync<List<Blog>>(Services.ClientEnum.EndPointEnum.Blogs, $"/mappingField/{Account.AccountFieldMappingId}", MethodEnum.GET, null);
                if (result1.IsSuccess)
                {
                    var blogList = result1.Data;
                    Blogs = blogList;
                }
                else
                {
                    Error(result1.ErrorMessage);
                }
            }
            else
            {
                Error(accountResult.ErrorMessage);
            }
        }
        
      
        private IActionResult Error(string error)
        {
            TempData["Error"] = error;
            TempData["PageName"] = "Student Profile";
            return RedirectToPage("/Error");
        }
    }
}
