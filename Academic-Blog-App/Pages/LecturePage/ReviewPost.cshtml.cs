using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Response;
using Academic_Blog_App.Services.ClientEnum;
using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Academic_Blog_App.Pages.LecturePage
{
    public class ReviewPostModel : PageModel
    {
        private ApiHelper _apiHelper;
        [BindProperty]
        public List<Blog> Blogs { get; set; }
        public LoginResponse CurrentAccount { get; set; } 
        public ReviewPostModel(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            CurrentAccount = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");
            var result =  await _apiHelper.FetchODataAsync<List<Account>>(Services.ClientEnum.EndPointEnum.Accounts, $"?$filter=id eq {CurrentAccount.Id}");
            if (result.IsSuccess)
            {
                var account = result.Data[0];
                var result1 = await _apiHelper.FetchApiAsync<List<Blog>>(Services.ClientEnum.EndPointEnum.Blogs, $"/mappingField/{account.AccountFieldMappingId}", MethodEnum.GET,null);
                if (result1.IsSuccess)
                {
                    var blogList = result1.Data;
                    Blogs = blogList;
                }
            }
                          
            return Page();
        }
    }
}
