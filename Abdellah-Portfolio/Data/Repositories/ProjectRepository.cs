using Abdellah_Portfolio.Data.Entities;

namespace Abdellah_Portfolio.Data.Repositories
{
    public static class ProjectRepository
    {
        private static AppDbContext _context = new AppDbContext();
        public static int Add(Project project)
        {
            _context.Add(project);
            _context.SaveChanges();
            return project.Id;
        }
        public static void Update(Project project)
        {
            _context.Update(project);
            _context.SaveChanges();
        }
        public static void Delete(Project project)
        {
            _context.Remove(project);
            _context.SaveChanges();
        }
        public static Project? GetById(int id)
        {
            return _context.Projects.Find(id);
        }
        public static IEnumerable<Project> GetPage(int page , int pageSize) 
        {
            return _context.Projects.Skip(page * pageSize).Take(pageSize);
        }
    }
}
