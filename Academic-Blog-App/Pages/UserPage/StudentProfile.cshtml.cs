using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Response;
using Academic_Blog_App.Services.ClientAjax;
using Academic_Blog_App.Services.ClientEnum;
using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Evaluation;

namespace Academic_Blog_App.Pages.UserPage.Student
{
    public class StudentProfileModel : PageModel
    {
        private readonly ApiHelper _apiHelper;
        public StudentProfileModel(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public List<Blog> Blogs { get; set; } = default!;
        public Account Account { get; set; } = default!;
        public int awardEarned = 0, totalViewed = 0, mostViewedBlog = 0, totalComment = 0, totalBlog = 0;

        public async Task<IActionResult> OnGetAsync(string? userId)
        {
            if (userId == null)
            {
                return RedirectToPage("/Index");
            }
            var acc = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");
            bool currentProfile = false;
            if (acc != null)
            {
                if(acc.Id == Guid.Parse(userId))
                {
                    if (!acc.AccountStatus.Equals("BANNED"))
                    {
                        currentProfile = true;
                    }
                }
            }

            await FetchAll(userId);
            await AwardsCaculateAsync(userId);
            return Page();
        }


        private async Task FetchAll(string? userId)
        {
            var blogResult = await _apiHelper.FetchODataAsync<List<Blog>>(EndPointEnum.Blogs, $"?$filter=AuthorId eq {Guid.Parse(userId)}");
            var accountResult = await _apiHelper.FetchODataAsync<List<Account>>(EndPointEnum.Accounts, $"?$filter=Id eq {Guid.Parse(userId)}");
            if (blogResult.IsSuccess && accountResult.IsSuccess)
            {
                Blogs = blogResult.Data;
                Account = accountResult.Data[0];
            }
            else
            {
                Error(blogResult.ErrorMessage);
            }
        }
        private async Task AwardsCaculateAsync(string? userId)
        {
            var blogsResult = await _apiHelper.FetchODataAsync<List<Blog>>(EndPointEnum.Blogs,$"?$filter=AuthorId eq {Guid.Parse(userId)}");
            var commentResult = await _apiHelper.FetchODataAsync<List<Comment>>(EndPointEnum.Comments, $"?$filter=CommentorId eq {Guid.Parse(userId)}");
            if (blogsResult.IsSuccess && commentResult.IsSuccess)
            {
                mostViewedBlog = blogsResult.Data.OrderByDescending(b => b.View).First().View; //[Most Viewd Blog]
                totalViewed = blogsResult.Data.Sum(b => b.View); //[Blog View Champion]
                totalComment = commentResult.Data.Count(); //[Comment Machine]
                totalBlog = blogsResult.Data.Count(); // [Blogging Machine]

                awardEarned += CaculateAwardEarned(mostViewedBlog);
                awardEarned += CaculateAwardEarned(totalViewed);
                awardEarned += CaculateAwardEarned(totalComment);

                if (totalBlog >= 3)
                {
                    awardEarned += 1;
                }
                if (totalBlog >= 5)
                {
                    awardEarned += 1;
                }
                if (totalBlog >= 7)
                {
                    awardEarned += 1;
                }
                if (totalBlog >= 10)
                {
                    awardEarned += 1;
                }
            }
            else
            {
                Error(blogsResult.ErrorMessage);
            }

        }

        private static int CaculateAwardEarned(int MilestonesAwardEarned)
        {
            int awardEarned = 0;
            if (MilestonesAwardEarned >= 25)
            {
                awardEarned += 1;
            }
            if (MilestonesAwardEarned >= 50)
            {
                awardEarned += 1;

            }
            if (MilestonesAwardEarned >= 75)
            {
                awardEarned += 1;
            }
            if (MilestonesAwardEarned >= 100)
            {
                awardEarned += 1;
            }

            return awardEarned;
        }

        private IActionResult Error(string error)
        {
            TempData["Error"] = error;
            TempData["PageName"] = "Student Profile";
            return RedirectToPage("/Error");
        }
    }
}
