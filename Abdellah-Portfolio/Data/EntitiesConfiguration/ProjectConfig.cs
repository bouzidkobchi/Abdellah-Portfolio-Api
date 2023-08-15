using Abdellah_Portfolio.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abdellah_Portfolio.Data.EntitiesConfiguration
{
    public static class ProjectConfig
    {
        public static ModelBuilder AddProjectEntity(this ModelBuilder modelBuilder)
        {
            var ProjectEntity = modelBuilder.Entity<Project>();

            ProjectEntity.Property(P => P.ProjectName)
                .IsRequired()
                .HasMaxLength(50);

            ProjectEntity.Property(P => P.About)
                .HasMaxLength(1000);

            ProjectEntity.Property(P => P.GithubUrl)
                .HasMaxLength (200);

            return modelBuilder;
        }
    }
}
