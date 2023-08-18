using Abdellah_Portfolio.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abdellah_Portfolio.Data.EntitiesConfiguration
{
    public static class UserConfig
    {
        public static ModelBuilder AddUserEntity(this ModelBuilder modelBuilder)
        {
            var UserEntity = modelBuilder.Entity<User>();

            UserEntity.Property(u => u.UserName)
                .HasMaxLength(50)
                .IsRequired();

            UserEntity.Property(U => U.PasswordHash)
                .HasMaxLength(250)
                .IsRequired();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            UserEntity.HasData
                (
                    new User 
                    {
                            Id = 1 , 
                            UserName = "abdellah bechraire" , 
                            CreatedAt = DateTime.Now , 
                            PasswordHash = config.GetSection("RootUserPasswordHash").Value ,
                    }
                );

            return modelBuilder;
        }
    }
}
