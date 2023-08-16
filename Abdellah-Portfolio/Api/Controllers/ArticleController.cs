using Abdellah_Portfolio.Data.Entities;
using Repo = Abdellah_Portfolio.Data.Repositories.ArticleRepository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Abdellah_Portfolio.Api.Controllers
{
    public class ArticleController : Controller
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("/articles")]
        public JsonResult Add([Required] string title, string description, [Required] string content, IFormFile picture)
        {
            JsonResult response;
            // 400
            // save the picture :
            if(picture is not null)
            {
                string extension = picture.FileName.Split('.').Last();
                var allowedExtensions = new string[] { "png", "jpg", "jpeg" };
                if (!allowedExtensions.Contains(extension))
                {
                    response = Json(new
                    {
                        message = "file extension not supported ."
                    });
                    response.StatusCode = 400;
                    return response;
                }
            }

            // 200
            string picturePath = Path.Combine(Path.GetFullPath("Media"), DateTime.Now.ToString("DD-MM-yyyy HH-mm-ss ") + picture.FileName);
            var stream = System.IO.File.Create(picturePath);
            picture.CopyTo(stream);
            stream.Close();

            var article = new Article { Title = title, Description = description, Content = content, PicturePath = picturePath };
            int articleId = Repo.Add(article);

            response = Json(new
            {
                message = "article added successfuly .",
                articleId
            });
            response.StatusCode = 200;
            return response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("/articles")]
        public JsonResult Update([Required] int articleId)
        {
            var article = Repo.GetById(articleId);
            JsonResult response;

            // 404
            if (article is null)
            {
                response = Json(new
                {
                    message = "article not found ."
                });
                response.StatusCode = 404;
                return response;
            }

            // 200
            Repo.Update(article);
            response = Json(new
            {
                messgae = "article updated successfuly ."
            });

            response.StatusCode = 200;
            return response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("/articles")]
        public JsonResult Delete([Required] int articleId)
        {
            var article = Repo.GetById(articleId);
            JsonResult response;

            // 404
            if (article is null)
            {
                response = Json(new
                {
                    message = "article not found ."
                });
                response.StatusCode = 404;
                return response;
            }

            // 200
            Repo.Delete(article);
            response = Json(new
            {
                message = "article deleted successfuly ."
            });
            return response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/articles")]
        public JsonResult GetPage(int page = 0, int pageSize = 1)
        {
            // 200
            var response = Json(new
            {
                articles = Repo.GetPage(page, pageSize)
            });
            return response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/articles/{id:int}")]
        public JsonResult Get(int id)
        {
            var article = Repo.GetById(id);
            JsonResult response;

            // 404
            if (article is null)
            {
                response = Json(new
                {
                    message = "article not found ."
                });
                response.StatusCode = 404;
                return response;
            }

            // 200
            response = Json(new
            {
                article
            });
            return response;
        }
    }
}
