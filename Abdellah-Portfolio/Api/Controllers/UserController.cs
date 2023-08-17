using Abdellah_Portfolio.Data.Repositories;
using Abdellah_Portfolio.Data.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Abdellah_Portfolio.Api.Controllers
{
    public class UserController : Controller
    {
        // need to config
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("/login")]
        public JsonResult Login(string username, string password)
        {
            JsonResult response;
            
            // 400
            if(username is null || password is null )
            {
                response = Json(new
                {
                    message = "login failed , username or password are not passed"
                });
                response.StatusCode = 400;
                return response;
            }

            // 401
            var user = UserRepository.GetUser();
            if(!string.Equals(user.UserName , username) || !Hash.VerifyPasswordHash(user , password))
            {
                response = Json(new
                {
                    message = "login failed , username or password are not valid"
                });
                response.StatusCode = 401;
                return response;
            }

            // 200
            response = Json(new
            {
                message = "login successed"
            });
            Response.Cookies.Append("key", "kobchi"); // login cookie
            return response;
        }

        [HttpPost("/logout")]
        public JsonResult Logout()
        {
            // 200
            JsonResult response;
            string? value;
            if(Request.Cookies.TryGetValue("key" , out value))
            {
                Response.Cookies.Delete("key");
                response = Json(new
                {
                    message = "logout successed"
                });
            }
            else
            {
                response = Json(new
                {
                    message = "you are already logout"
                });
            }
            return response;
        }

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("/ChangePassword")]
        public JsonResult ChangePassword(string newPassword)
        {
            JsonResult response;
            // 200
            if (Auth.IsLogin(Request))
            {
                UserRepository.ChangePassword(newPassword);
                response = Json(new
                {
                    message = "password changed successfuly"
                });
                return response;
            }

            // 401
            response = Json(new
            {
                message = "you are not login"
            });
            response.StatusCode = 401;
            return response;
        }

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("/ChangeUsername")]
        public JsonResult ChangeUsername(string newUsername)
        {
            JsonResult response;
            // 200
            if (Auth.IsLogin(Request))
            {
                UserRepository.ChangeUsername(newUsername);
                response = Json(new
                {
                    message = "username changed successfuly"
                });
                return response;
            }

            // 401
            response = Json(new
            {
                message = "you are not login"
            });
            response.StatusCode = 401;
            return response;
        }

        // public login (done)
        // public logout (done)
        // public change user name (done)
        // public change password (done)

    }
}
