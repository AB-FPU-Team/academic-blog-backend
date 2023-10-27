using Microsoft.AspNetCore.SignalR;

namespace Academic_Blog_App.Services.ClientAjax
{
    public class CenterHub : Hub
    {
        public async Task TrackPost(string postId)
        {
           await  Clients.All.SendAsync("TrackPost", postId);
        }
    }
}
