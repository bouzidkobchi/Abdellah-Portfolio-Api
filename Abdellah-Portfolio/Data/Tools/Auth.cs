using Abdellah_Portfolio.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Abdellah_Portfolio.Data.Tools
{
    public static class Auth
    {
        public static bool IsLogin(HttpRequest Request)
        {
            string? key;

            if(Request.Cookies.TryGetValue("key",out key))
            {
                if(string.Equals(UserRepository.GetKey() , key))
                {
                    return true;
                }
            }
            return false;
        }

        public static void Login(HttpResponse Response)
        {
            Response.Cookies.Append("key", UserRepository.UpdateToken(), new CookieOptions
            {
                MaxAge = new TimeSpan(100, 0, 0, 0)
            });
        }
    }
}
