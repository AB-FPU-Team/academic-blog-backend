using Academic_Blog_App.Services.ClientAjax;
using Academic_Blog_App.Services.ClientEnum;
using Microsoft.AspNetCore.SignalR;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace Academic_Blog_App.Services.Helper
{
    public class ApiHelper
    {
        private readonly HttpClient _httpClient;
        private readonly IHubContext<CenterHub> _hubContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string Scheme = SchemeEnum.HTTPS.ToString();
        private readonly string Host = "localhost";
        private readonly string Port = "5047";
        private string RootUrl;
        private string Token;
        private string CallUrl, JsonContent, ResponseCotent;
        private HttpResponseMessage Response;

        public ApiHelper(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IHubContext<CenterHub> hubContext)
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            _httpContextAccessor = httpContextAccessor;
            _hubContext = hubContext;
            Token = SessionHelper.GetObjectFromJson<String>(_httpContextAccessor.HttpContext.Session, "Token");

        }

        public async Task<ResultHelper<T>> FetchApiAsync<T>(EndPointEnum endPoint, string postFixUrl, MethodEnum method, object data)
        {
            RootUrl = Scheme + "://" + Host + ":" + Port + "/" + PatchEnum.api.ToString() + "/";
            CallUrl = RootUrl + endPoint.ToString() + postFixUrl;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (Token != "" || Token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            JsonContent = data != null ? JsonSerializer.Serialize(data) : "";

            if (method.Equals(MethodEnum.GET))
            {
                Response = await _httpClient.GetAsync(CallUrl);
            }
            if (method.Equals(MethodEnum.DELETE))
            {
                Response = await _httpClient.DeleteAsync(CallUrl);
            }

            if (method.Equals(MethodEnum.POST))
            {
                Response = await _httpClient.PostAsync(CallUrl, new StringContent(JsonContent, Encoding.UTF8, "application/json"));
            }

            if (method.Equals(MethodEnum.PUT))
            {
                if (JsonContent != "" || JsonContent != null)
                {
                    Response = await _httpClient.PutAsync(CallUrl, new StringContent(JsonContent, Encoding.UTF8, "application/json"));
                }
                else
                {
                    Response = await _httpClient.PutAsync(CallUrl, null);
                }
            }

            if (Response!.IsSuccessStatusCode)
            {
                ResponseCotent = await Response.Content.ReadAsStringAsync();
            }
            else
            {
                string errorMessage = $"Error: {Response.StatusCode}";
                return ResultHelper<T>.Fail(errorMessage);
            }

            if (string.IsNullOrEmpty(ResponseCotent))
            {
                return ResultHelper<T>.Success();
            }

            T result = JsonSerializer.Deserialize<T>(ResponseCotent, options)!;
            return ResultHelper<T>.Success(result);
        }

        public async Task<ResultHelper<T>> FetchODataAsync<T>(EndPointEnum endPoint, string postFixUrl)
        {
            RootUrl = Scheme + "://" + Host + ":" + Port + "/" + PatchEnum.odata.ToString() + "/";
            CallUrl = RootUrl + endPoint.ToString() + postFixUrl;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (Token != "" || Token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            Response = await _httpClient.GetAsync(CallUrl);

            if (Response!.IsSuccessStatusCode)
            {
                ResponseCotent = await Response.Content.ReadAsStringAsync();
            }
            else
            {
                string errorMessage = $"Error: {Response.StatusCode}";
                return ResultHelper<T>.Fail(errorMessage);
            }

            T result = JsonSerializer.Deserialize<T>(ResponseCotent, options)!;
            return ResultHelper<T>.Success(result);
        }
        public async void DoAjaxConnectionAsync(string ajaxConnection, string subData)
        {
            _httpContextAccessor.HttpContext!.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            _httpContextAccessor.HttpContext!.Response.Headers["Pragma"] = "no-cache";
            _httpContextAccessor.HttpContext!.Response.Headers["Expires"] = "0";
            if (subData != "")
            {
                await _hubContext.Clients.All.SendAsync(ajaxConnection, subData);
            }
            else
            {
                await _hubContext.Clients.All.SendAsync(ajaxConnection);
            }
        }
    }
}
