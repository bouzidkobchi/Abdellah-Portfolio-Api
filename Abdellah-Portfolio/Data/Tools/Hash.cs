using Abdellah_Portfolio.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Abdellah_Portfolio.Data.Tools
{
    public static class Hash
    {
        private static readonly PasswordHasher<User> hasher = new PasswordHasher<User>();
        public static string GeneratePasswordHash(User user ,  string password)
        {
            return hasher.HashPassword(user, password);
        }
        public static bool VerifyPasswordHash(User user, string password)
        {
            return hasher.VerifyHashedPassword(user, user.PasswordHash , password) == PasswordVerificationResult.Success ? true : false ;
        }
    }
}
