using Academic_Blog.Domain.Models;
using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Academic_Blog_App.Services.ClientEnum;
using Academic_Blog.PayLoad.Request.TrackingViewBlog;
using Academic_Blog.PayLoad.Response;
using Academic_Blog.PayLoad.Request.Comment;
using System.Xml.Linq;
using NuGet.Protocol.Plugins;

namespace Academic_Blog_App.Pages.AjaxPage
{
    public class AjaxHandelModel : PageModel
    {
        private readonly ApiHelper _apiHelper;

        public AjaxHandelModel(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<IActionResult> OnGetEditComment(string commentId, string content)
        {
            //Update
            var commentResult = await _apiHelper.FetchODataAsync<List<Comment>>(EndPointEnum.Comments, $"?$filter=id eq {Guid.Parse(commentId)}");
            var currentUser = await _apiHelper.FetchApiAsync<Account>(EndPointEnum.Accounts, "/currentUser", MethodEnum.GET, null);
            var acc = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");
            if (commentResult.IsSuccess && currentUser.IsSuccess)
            {
                var response = new
                {
                    Account = currentUser.Data,
                    Comment = commentResult.Data[0],
                    Login = acc != null && !acc.AccountStatus.Equals("BANNED") ? true : false,
                };
                return new JsonResult(response);
            }
            else
            {
                Error("Server Error");
            }
            return new JsonResult(null);
        }
        public async Task<IActionResult> OnGetEditOption(string commentId)
        {
            var commentResult = await _apiHelper.FetchODataAsync<List<Comment>>(EndPointEnum.Comments, $"?$filter=id eq {Guid.Parse(commentId)}");
            var currentUser = await _apiHelper.FetchApiAsync<Account>(EndPointEnum.Accounts, "/currentUser", MethodEnum.GET, null);
            var acc = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");
            if (commentResult.IsSuccess && currentUser.IsSuccess)
            {
                var response = new
                {
                    Account = currentUser.Data,
                    Comment = commentResult.Data[0],
                    Login = acc != null && !acc.AccountStatus.Equals("BANNED") ? true : false,
                };
                return new JsonResult(response);
            }
            else
            {
                Error("Server Error");
            }
            return new JsonResult(null);
        }

        public async Task<IActionResult> OnGetDeleteOption(string commentId)
        {
            var deleteCommentResult = await _apiHelper.FetchApiAsync<String>(EndPointEnum.Comments, $"?id={Guid.Parse(commentId)}", MethodEnum.DELETE, null);
            if (deleteCommentResult.IsSuccess)
            {
                return new JsonResult(new { success = true });
            }
            return new JsonResult(new { success = false });
        }
        public async Task<IActionResult> OnGetCreateNewComment(string commentData)
        {
            var currentBlog = SessionHelper.GetObjectFromJson<Blog>(HttpContext.Session, "CurrentBlog");
            CreateCommentRequest newComment = new CreateCommentRequest
            {
                Content = commentData,
                BlogId = currentBlog.Id
            };
            try
            {
                var result = await _apiHelper.FetchApiAsync<Comment>(EndPointEnum.Comments, "", MethodEnum.POST, newComment);

                if (result.IsSuccess)
                {
                    var currentAccountResult = await _apiHelper.FetchApiAsync<Account>(EndPointEnum.Accounts, "/currentUser", MethodEnum.GET, null);

                    var acc = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");
                    Boolean Login = false;
                    if (acc != null)
                    {
                        if (!acc.AccountStatus.Equals("BANNED"))
                        {
                            Login = true;
                        }
                    }
         
                    var response = new
                    {
                        Account = currentAccountResult.Data,
                        Comment = result.Data,
                        Login = Login,
                    };
                    return new JsonResult(response);
                }
            }
            catch (Exception ex)
            {
                Error("Several Error Has Been Occur!");
            }
            return new JsonResult(null);
        }
        public async Task<IActionResult> OnGetCreateReply(string commentId, string replyComment, string spaddingInt)
        {
            var currentBlog = SessionHelper.GetObjectFromJson<Blog>(HttpContext.Session, "CurrentBlog");
            CreateCommentRequest newComment = new CreateCommentRequest
            {
                Content = replyComment,
                ReplyToId = Guid.Parse(commentId),
                BlogId = currentBlog.Id

            };
            try
            {
                var result = await _apiHelper.FetchApiAsync<Comment>(EndPointEnum.Comments, "", MethodEnum.POST, newComment);

                if (result.IsSuccess)
                {
                    var currentAccountResult = await _apiHelper.FetchApiAsync<Account>(EndPointEnum.Accounts, "/currentUser", MethodEnum.GET, null);
                    int distance = int.Parse(spaddingInt) + 58;

                    var acc = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");
                    Boolean Login = false;
                    if (acc != null)
                    {
                        if (!acc.AccountStatus.Equals("BANNED"))
                        {
                            Login = true;
                        }
                    }

                    var response = new
                    {
                        Account = currentAccountResult.Data,
                        Comment = result.Data,
                        Distance = distance,
                        Login = Login,
                    };
                    return new JsonResult(response);
                }
            }
            catch(Exception ex)
            {
                Error("Several Error Has Been Occur!");
            }                 
            return new JsonResult(null);
        }

        public async Task<IActionResult> OnGetReport(string reportCommentId, string selectedReason)
        {

            return new JsonResult(new { success = true });
        }


        public async Task<IActionResult> OnGetReply(string commentId, string distanceInt)
        {
            int Distances = int.Parse(distanceInt) + 58;

            List<Comment> Replys = new List<Comment>();
            List<String> FeedBacks = new List<String>();

            var currentBlog = SessionHelper.GetObjectFromJson<Blog>(HttpContext.Session, "CurrentBlog");
            var replyResult = await _apiHelper.FetchODataAsync<List<Comment>>(EndPointEnum.Comments, $"?$filter=blogId eq {currentBlog.Id!}  and replyToId eq {Guid.Parse(commentId)}");
            var allCommentResult = await _apiHelper.FetchApiAsync<List<Comment>>(EndPointEnum.Comments, "", MethodEnum.GET, null);
            var AccountReplys = await _apiHelper.FetchApiAsync<List<Account>>(EndPointEnum.Accounts, "", MethodEnum.GET, null);
            if (replyResult.IsSuccess && allCommentResult.IsSuccess && AccountReplys.IsSuccess)
            {
                Replys = replyResult.Data;
                foreach (var reply in Replys)
                {
                    var filteredComments = allCommentResult.Data.Where(comment => comment.ReplyToId == reply.Id);

                    String feedBack = reply.Id.ToString() + ":" + filteredComments.Count();
                    FeedBacks.Add(feedBack);
                }
            }
            else
            {
                Error(replyResult.ErrorMessage + "\n" + allCommentResult.ErrorMessage);
            }
            var currentAccountResult = await _apiHelper.FetchApiAsync<Account>(EndPointEnum.Accounts, "/currentUser", MethodEnum.GET, null);
            var acc = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");
            Boolean Login = false;
            if (acc != null)
            {
                if (!acc.AccountStatus.Equals("BANNED"))
                {
                    Login = true;
                }
            }
            var result = new
            {
                AccountReplys = AccountReplys.Data,
                Replys = Replys.OrderByDescending(reply => reply.CreateTime).ToList(),
                Distance = Distances,
                FeedBacks = FeedBacks,
                Login = Login,
                CurrentAccount = currentAccountResult.Data
            };
            return new JsonResult(result);
        }

        public IActionResult OnGetBlogId()
        {
            var currentBlog = SessionHelper.GetObjectFromJson<Blog>(HttpContext.Session, "CurrentBlog");
            return new JsonResult(new { blogId = currentBlog.Id });
        }

        public async Task<IActionResult> OnGetTrackBlog(string blogId, string fingerprint)
        {
            ResultHelper<List<TrackingViewBlog>> result = await FetchingBlogs();
            var account = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");

            if (result.IsSuccess)
            {
                if (account != null)
                {
                    if (!CheckBlogs(Guid.Parse(blogId), account.Id.ToString(), result))
                    {
                        await CreateNewTracking(Guid.Parse(blogId), account.Id.ToString());
                        return new JsonResult(new { success = true });
                    }

                }
                else
                {
                    if (!CheckBlogs(Guid.Parse(blogId), fingerprint, result))
                    {
                        await CreateNewTracking(Guid.Parse(blogId), fingerprint);
                        return new JsonResult(new { success = true });
                    }
                }
            }
            else
            {
                Error(result.ErrorMessage);
            }

            return new JsonResult(new { success = false });
        }

        private async Task<ResultHelper<List<TrackingViewBlog>>> FetchingBlogs()
        {
            return await _apiHelper.FetchApiAsync<List<TrackingViewBlog>>(EndPointEnum.TrackingViewBlogs, "", MethodEnum.GET, null);
        }

        private async Task CreateNewTracking(Guid blogId, string trackingId)
        {
            TrackingViewBlogRequest newTracking = new TrackingViewBlogRequest
            {
                BlogId = blogId,
                TrackingId = trackingId,
            };
            var createResult = await _apiHelper.FetchApiAsync<String>(EndPointEnum.TrackingViewBlogs, "", MethodEnum.POST, newTracking);
            if (!createResult.IsSuccess)
            {
                Error(createResult.ErrorMessage);
            }
        }

        private static bool CheckBlogs(Guid blogId, string trackingId, ResultHelper<List<TrackingViewBlog>> result)
        {
            List<TrackingViewBlog> TrackingList = result.Data;

            foreach (var tracking in TrackingList)
            {
                if (tracking.BlogId == blogId && tracking.TrackingId == trackingId)
                {
                    return true;
                }
            }
            return false;
        }

        private IActionResult Error(string error)
        {
            TempData["Error"] = error;
            TempData["PageName"] = "Tracking";
            return RedirectToPage("/Error");
        }
    }
}
