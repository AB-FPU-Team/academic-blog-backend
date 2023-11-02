using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Request;
using Academic_Blog.PayLoad.Response;
using Academic_Blog_App.Services;
using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Session;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Academic_Blog_App.Pages.AdminPage
{
    public class AccountDetailModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private string accountUrl, accountbannedUrl;

        public AccountDetailModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            accountUrl = "http://localhost:5047/odata/Accounts";
            accountbannedUrl = "http://localhost:5047/odata/Accounts";
        }

        [BindProperty]
        public Account Accounts { get; set; }
        public async Task<IActionResult> OnGetAsync(string? Id)
        {
            if (Id == null)
            {
                return RedirectToPage("/AdminPage/CommentDetail");
            }

            //String token = "sdafafasgegergeregeeqegerq3hehwgwegwer";
            var loginAccount = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");

            var token = loginAccount.AccessToken.ToString();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync(accountUrl + $"?$filter=id eq {Id}");


            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var outer = Newtonsoft.Json.JsonConvert.DeserializeObject<OData<object[]>>(content);
                Accounts = Newtonsoft.Json.JsonConvert.DeserializeObject<Account>(outer.value[0].ToString());
            }
            else
            {
                ViewData["Error"] = response.ToString();
            }
            return Page();
        }
        
    }
}
