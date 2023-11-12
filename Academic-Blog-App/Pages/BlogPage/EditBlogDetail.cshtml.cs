using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Request.Blog;
using Academic_Blog.PayLoad.Response;
using Academic_Blog_App.Services.ClientAjax;
using Academic_Blog_App.Services.ClientEnum;
using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Differencing;

namespace Academic_Blog_App.Pages.BlogPage
{
    public class EditBlogDetailModel : PageModel
    {
        private readonly ApiHelper _apiHelper;
        private readonly string UploadsFolderPath = "wwwroot/images";
        public EditBlogDetailModel(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        [BindProperty]
        public Blog Blog { get; set; } = default!;
        public List<Category> Categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? blogId)
        {
            if (blogId == null)
            {
                Error("Blog Not Regconize");
            }
            var acc = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");
            if (acc == null)
            {
                return RedirectToPage("/Index");
            }
            await FetchAll(blogId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile image, string blogId)
        {
            var imageUrl = "";
            if (image != null && image.Length > 0)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                var imagePath = Path.Combine(UploadsFolderPath, imageName);

                using (var stream = System.IO.File.Create(imagePath))
                {
                    await image.CopyToAsync(stream);
                }
                imageUrl = "images/" + imageName;

            }
            UpdateBlogRequest updateBlogRequest = new UpdateBlogRequest
            {
                Thumbnal_Url = imageUrl,
                Title = Blog.Title,
                Description = Blog.Description,
                CategoryId = Guid.Parse(Request.Form["statusSelect"]!)
            };
            var result = await _apiHelper.FetchApiAsync<String>(EndPointEnum.Blogs, $"/student/{Guid.Parse(blogId)}/edit", MethodEnum.PUT, updateBlogRequest);
            if (result.IsSuccess)
            {
                ViewData["NotificationMessage"] = "Update successfully";
                await FetchAll(blogId);
                return Page();
            }
            return Error("Update Failed: " + result.ErrorMessage);
        }

        private async Task FetchAll(string? blogId)
        {
            var blogResult = await _apiHelper.FetchODataAsync<List<Blog>>(EndPointEnum.Blogs, $"?$filter=Id eq {Guid.Parse(blogId)}");
            var categoryResult = await _apiHelper.FetchApiAsync<List<Category>>(EndPointEnum.Categories, "", MethodEnum.GET, null);
            if (blogResult.IsSuccess && categoryResult.IsSuccess)
            {
                Blog = blogResult.Data[0];
                Categories = categoryResult.Data;
            }
            else
            {
                Error(blogResult.ErrorMessage + "\n" + categoryResult.ErrorMessage);
            }
        }

        private IActionResult Error(string error)
        {
            TempData["Error"] = error;
            TempData["PageName"] = "Edit Blog Detail";
            return RedirectToPage("/Error");
        }
    }
}
