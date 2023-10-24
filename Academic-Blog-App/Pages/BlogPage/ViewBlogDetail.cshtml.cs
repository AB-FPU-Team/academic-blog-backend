using Academic_Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Academic_Blog_App.Pages.BlogPage
{
    public class ViewBlogDetailModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private string blogUrl, accountUrl;

        public ViewBlogDetailModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            blogUrl = "http://localhost:5047/api/Blogs";
            accountUrl = "http://localhost:5047/odata/Account";
        }

        [BindProperty]
        public Blog Blog { get; set; } = default!;
        public Account Account { get; set; }
        public async Task<IActionResult> OnGetAsync(string? blogId, string? authorId)
        {
            if(blogId == null || authorId == null)
            {
                return RedirectToPage("/Index");
            }

            //String token = "sdafafasgegergeregeeqegerq3hehwgwegwer";

            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync(blogUrl + $"/{Guid.Parse(blogId)}");
            HttpResponseMessage accountResponse = await _httpClient.GetAsync(accountUrl + $"?$filter=id eq {authorId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                string accountContent = await accountResponse.Content.ReadAsStringAsync() ;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                Blog = JsonSerializer.Deserialize<Blog>(content, options)!;
                Account = JsonSerializer.Deserialize<Account>(accountContent, options)!;
            }
            else
            {
                ViewData["Error"] = response.ToString();
            }
            return Page();
        }
    }
}
