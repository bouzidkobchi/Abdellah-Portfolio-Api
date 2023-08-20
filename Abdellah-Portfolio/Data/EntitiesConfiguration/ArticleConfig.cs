using Abdellah_Portfolio.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abdellah_Portfolio.Data.EntitiesConfiguration
{
    public static class ArticleConfig
    {
        public static ModelBuilder AddArticleEntity(this ModelBuilder modelBuilder)
        {
            var ArticleEntity = modelBuilder.Entity<Article>();

            // Title :
            ArticleEntity.Property(A => A.Title)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            // Description :
            ArticleEntity.Property(A => A.Description)
                .IsUnicode()
                .IsRequired(false);

            // Content :
            ArticleEntity.Property(A => A.Content)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode();

            // PicturePath :
            ArticleEntity.Property(A => A.PicturePath)
                .HasMaxLength(100);

            return modelBuilder;
        } 
    }
}
