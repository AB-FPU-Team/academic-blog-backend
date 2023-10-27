using Academic_Blog_App.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Academic_Blog_App.Pages.AjaxPage
{
    public class AjaxHandelModel : PageModel
    {
        private readonly ApiHelper _apiHelper;

        public AjaxHandelModel(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<IActionResult> OnPostTrackPost(string postId, string fingerprint)
        {
           
            return new JsonResult(new { success = true });
        }
    }
}
