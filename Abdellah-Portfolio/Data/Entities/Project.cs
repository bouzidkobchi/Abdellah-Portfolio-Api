namespace Abdellah_Portfolio.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string About { get; set; }
        public string GithubUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
