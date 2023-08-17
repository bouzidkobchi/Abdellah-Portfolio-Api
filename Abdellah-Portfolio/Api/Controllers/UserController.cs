using Microsoft.AspNetCore.Mvc;

namespace Abdellah_Portfolio.Api.Controllers
{
    public class UserController : Controller
    {
        // need to config
        [HttpPost("/users")]
        public JsonResult Login(string username, string password)
        {
            JsonResult response;
            response = Json(new
            {
                user = "bouzid"
            });
            Response.Cookies.Append("bouzid", "kobchi");
            return response;
        }

    }
}
