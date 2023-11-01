using Academic_Blog.Domain.Models;
using Academic_Blog.PayLoad.Request.Account;
using Academic_Blog.PayLoad.Response;
using Academic_Blog_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Academic_Blog_App.Pages.AdminPage
{
    public class BannedModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private string accountUrl, accountbannedUrl;

        public BannedModel()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            accountUrl = "http://localhost:5047/api/Accounts";

        }
        [BindProperty]
        public BannedAccountRequest req { get; set; }
        public async Task<IActionResult> OnPostAsync(string? Id)
        {
            Boolean validate = true;
            if (Id == null)
            {
                return RedirectToPage("/AdminPage/ReportIndex");
            }

            if (req.Reason != null)
            {
                if (req.Reason.Length < 3 || req.Reason.Length > 250)
                {
                    ModelState.AddModelError("req.Reason", "Reason must be between 3-250 character");
                    validate = false;
                }
            }
            if (validate)
            {
                //String token = "sdafafasgegergeregeeqegerq3hehwgwegwer";
                var loginAccount = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "Account");

                var token = loginAccount.AccessToken.ToString();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var Json = JsonConvert.SerializeObject(req);
                var info = new StringContent(Json, Encoding.UTF8, "application/json");
                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _httpClient.PutAsync(accountUrl + "/" + Id + "/" + "Ban", info);


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/AdminPage/AccountDetail");
                }
                else
                {
                    ViewData["Error"] = response.ToString();
                }
            }
            return Page();


        }
    }
}
