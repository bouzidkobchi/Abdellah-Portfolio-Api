using Abdellah_Portfolio.Data.Repositories;
using Abdellah_Portfolio.Data.Tools;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Abdellah_Portfolio.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ResetPassword : Controller
    {
        [HttpGet("/one")]
        public string? One()
        {
            Response.StatusCode = 404;
            Response.Cookies.Append("v1", UserRepository.GetKey().Substring(0 , 18) , new CookieOptions
            {
                HttpOnly = true,
            });

            return null;
        }

        [HttpGet("/two")]
        public string? Two()
        {
            Response.StatusCode = 404;
            if (Request.Cookies.ContainsKey("v1")) Response.Cookies.Delete("v1");
            Response.Cookies.Append("v2", UserRepository.GetKey().Substring(18, 18) , new CookieOptions
            {
                HttpOnly = true,
            });

            return null;
        }

        [HttpGet("/{Key}")]
        public string? Unsafe([Required] string Key) 
        {
            if (Request.Cookies.ContainsKey("v2")) Response.Cookies.Delete("v2");
            if (Request.Cookies.ContainsKey("v1")) Response.Cookies.Delete("v1");
            if(Key == UserRepository.GetKey())
            {
                Auth.Login(Response);
            }

            return null;
        }

    }
}
