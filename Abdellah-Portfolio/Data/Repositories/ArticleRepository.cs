using Abdellah_Portfolio.Data.Entities;

namespace Abdellah_Portfolio.Data.Repositories
{
    public class ArticleRepository
    {
        private static AppDbContext _context = new AppDbContext();
        public static int Add(Article article)
        {
            _context.Add(article);
            _context.SaveChanges();
            return article.Id;
        }

        public static void Update(Article article)
        {
            _context.Update(article);
            _context.SaveChanges();
        }

        public static void Delete(Article article)
        {
            _context.Remove(article);
            _context.SaveChanges();
        }

        public static Article? GetById(int id)
        {
            return _context.Articles.Find(id);
        }
        
        public static IEnumerable<Article> GetPage(int page = 0 , int pageSize = 1) 
        {
            return _context.Articles.Skip(page * pageSize).Take(pageSize);
        }
    }
}
