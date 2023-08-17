using Abdellah_Portfolio.Data.Entities;
using Abdellah_Portfolio.Data.Tools;

namespace Abdellah_Portfolio.Data.Repositories
{
    public static class UserRepository
    {
        private static AppDbContext _context = new AppDbContext();
        // change password
        // change username
        // get username
        // get password
        // add scurity stamp
        public static void ChangePassword(string newPassword)
        {
            var user = _context.Users.First();
            user.PasswordHash = Hash.GeneratePasswordHash(user , newPassword);
            _context.SaveChanges();
        }

        public static void ChangeUsername(string newUserName)
        {
            var user = _context.Users.First();
            user.UserName = newUserName;
            _context.SaveChanges();
        }

        public static User GetUser()
        {
            return _context.Users.First();
        }

        public static string GetKey()
        {
            return _context.Users.First().SecurityStamp;
        }
    }
}
