using Academic_Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text.Json;

namespace Academic_Blog_App.Pages.BlogPage
{
    public class ViewAllBlogModel : PageModel
    {
        //private readonly HttpClient _httpClient;
        //private string blogUrl;

        //public ViewAllBlogModel() {
        //    _httpClient = new HttpClient();
        //    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        //    _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        //    blogUrl = "https://localhost:5047/api/Blogs";
        //}

        //[BindProperty]
        //public List<Blog> Blogs { get; set; } = default!;
        //public async Task<IActionResult> OnGetAsync() {
        //    HttpResponseMessage response = await _httpClient.GetAsync(blogUrl);

        //    if (response.IsSuccessStatusCode) {
        //        string content = await response.Content.ReadAsStringAsync();
        //        var options = new JsonSerializerOptions {
        //            PropertyNameCaseInsensitive = true
        //        };
        //        Blogs = JsonSerializer.Deserialize<List<Blog>>(content, options)!;
        //    }
        //    else {
        //        ViewData["Error"] = response.ToString();
        //    }
        //    return Page();
        //}
    }
}
