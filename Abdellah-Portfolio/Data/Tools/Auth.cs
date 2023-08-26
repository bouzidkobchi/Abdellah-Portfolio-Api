using Abdellah_Portfolio.Data.Repositories;

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
    }
}
