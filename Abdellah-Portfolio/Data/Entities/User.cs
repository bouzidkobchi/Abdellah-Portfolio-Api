namespace Abdellah_Portfolio.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string SecurityStamp {get ; set;} = Guid.NewGuid().ToString();
    }
}