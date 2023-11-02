using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Response;
using Academic_Blog_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Academic_Blog_App.Pages.AdminPage
{
    public class ReportIndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private string reportUrl;

        public ReportIndexModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            reportUrl = "http://localhost:5047/api/Reports";
        }


        [BindProperty]
        public List<Report> Reports { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            var loginAccount = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");
          
            var token= loginAccount.AccessToken.ToString();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync(reportUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                Reports = System.Text.Json.JsonSerializer.Deserialize<List<Report>>(content, options)!;
            }
            else
            {
                ViewData["Error"] = response.ToString();
            }
            return Page();
        }
    }
}
