using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Request;
using Academic_Blog.PayLoad.Response;
using Academic_Blog_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Xml.Linq;

namespace Academic_Blog_App.Pages.AdminPage
{
    public class CommentDetailModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private string commentUrl;

        public CommentDetailModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            commentUrl = "http://localhost:5047/odata/Comments";
        }

        [BindProperty]
        public Comment Comments { get; set; }
        public async Task<IActionResult> OnGetAsync(string? Id)
        {
            if (Id == null)
            {
                return RedirectToPage("/AdminPage/ReportIndex");
            }

            //String token = "sdafafasgegergeregeeqegerq3hehwgwegwer";
            var loginAccount = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");

            var token = loginAccount.AccessToken.ToString();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync(commentUrl + $"?$filter=id eq {Id}");


            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var outer = Newtonsoft.Json.JsonConvert.DeserializeObject<OData<object[]>>(content);
                Comments = Newtonsoft.Json.JsonConvert.DeserializeObject<Comment>(outer.value[0].ToString());
            }
            else
            {
                ViewData["Error"] = response.ToString();
            }
            return Page();
        }
    }
}
