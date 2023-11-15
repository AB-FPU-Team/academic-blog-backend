using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Request.Blog;
using Academic_Blog.PayLoad.Response.Blog;
using Academic_Blog_App.Services.ClientEnum;
using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Academic_Blog_App.Pages.BlogPage
{
    public class CreateNewBlogModel : PageModel
    {
        private readonly ApiHelper _apiHelper;
        private string blogUrl;
        private string categoryUrl;
        private readonly string UploadsFolderPath = "wwwroot/images";
        public CreateNewBlogModel(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
            blogUrl = "https://localhost:5047/api/Blogs";
            categoryUrl = "http://localhost:5047/api/Categories";
        }

        [BindProperty]
        public List<Category> Categories { get; set; }
        [BindProperty]
        public CreateNewBlogRequest CreateNewBlogRequest { get; set; }
        public async Task<IActionResult> OnGetAsync(string? userId)
        {
            if (userId == null)
            {
                return RedirectToPage("/Index");
            }
            await GetAll();
            return Page();
        }

        private async Task GetAll()
        {
            var response = await _apiHelper.FetchApiAsync<List<Category>>(EndPointEnum.Categories, "", MethodEnum.GET, null);
            if (response.IsSuccess)
            {

                Categories = response.Data;
            }
        }

        public async Task<IActionResult> OnPostCreateAsync(IFormFile image)
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
            
            CreateNewBlogRequest.Thumbnal_Url = imageUrl;
            var description = CreateNewBlogRequest.Description;
            CreateNewBlogRequest.Description = description;
            if (CreateNewBlogRequest.Description.Length < 100 )
            {
                return Page();

            }
            CreateNewBlogRequest.CategoryId = Guid.Parse(Request.Form["statusSelect"]);
            var x = CreateNewBlogRequest;
            var response = await _apiHelper.FetchApiAsync<BlogResponse>(EndPointEnum.Blogs, "", MethodEnum.POST, CreateNewBlogRequest);
            if (response.IsSuccess)
            {
                var result = response.Data;
                if (result != null)
                {
                    ViewData["NotificationMessage"] = "Create successfully";
                    await GetAll();
                    return Page();
                }
            }
            return RedirectToPage("/Error");
        }
    }
}
