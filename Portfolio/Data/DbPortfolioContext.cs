using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
namespace Portfolio.Data
{
    public class DbPortfolioContext : DbContext
    {
        public DbPortfolioContext(DbContextOptions<DbPortfolioContext> options) : base(options) { }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProjectCategory>(entity =>
            {
                entity.HasKey(pc => pc.IdProjectCategory);
                entity.Property(pc => pc.IdProjectCategory).UseMySqlIdentityColumn().ValueGeneratedOnAdd();

                entity.Property(pc => pc.NameCategory)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(pc => pc.Description)
                .HasMaxLength(100)
                .HasDefaultValue("Agregue una descripción")
                .IsRequired(false);

                entity.Property(pc => pc.ImageCategory)
               .HasColumnType("LONGBLOB")
               .IsRequired(false);

                entity.HasMany(pc => pc.Projects)
                .WithOne(pc => pc.ProjectCategory)
                .HasForeignKey(pc => pc.ProjectCategoryId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.ToTable("ProjectCategory");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.IdProject);

                entity.Property(p => p.IdProject).UseMySqlIdentityColumn().ValueGeneratedOnAdd();

                entity.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(p => p.Description)
                .HasMaxLength(2000)
                .HasDefaultValue("Agregue una descripción")
                .IsRequired(false);

                entity.Property(p => p.ImageProject)
                .HasColumnType("LONGBLOB")
                .IsRequired(false);

                entity.HasOne(p => p.ProjectCategory)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.ProjectCategoryId);

                entity.HasMany(p => p.Images)
                .WithOne(p => p.Project)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(p => p.ProjectTechnologies)
                .WithOne(p => p.Project)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.ToTable("Project");

            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(i => i.IdImage);

                entity.Property(i => i.IdImage).UseMySqlIdentityColumn().ValueGeneratedOnAdd();

                entity.Property(i => i.ImageBin)
                .HasColumnType("LONGBLOB")
                .IsRequired(false);

                entity.HasOne(i => i.Project)
                .WithMany(i => i.Images)
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.ToTable("Image");

            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.HasKey(t => t.IdTechnology);

                entity.Property(t => t.IdTechnology).UseMySqlIdentityColumn().ValueGeneratedOnAdd();

                entity.Property(t => t.NameTechnology)
               .IsRequired()
               .HasMaxLength(30);

                entity.Property(t => t.ImageIcon)
                .HasColumnType("LONGBLOB").IsRequired(false);

                entity.HasMany(t => t.ProjectTechnologies)
                .WithOne(t => t.Technology);
                //.HasPrincipalKey(t => t.IdTechnology);              //Podria habilitarla, pero funcionara sin ella
                entity.ToTable("Technology");


            });

            modelBuilder.Entity<ProjectTechnology>()
                .HasKey(pt => new { pt.ProjectId, pt.TechnologyId });

            modelBuilder.Entity<ProjectTechnology>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTechnologies)
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectTechnology>()
                .HasOne(pt => pt.Technology)
                .WithMany(t => t.ProjectTechnologies)
                .HasForeignKey(pt => pt.TechnologyId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ProjectTechnology>()
                 .ToTable("ProjectTechnology");

        }
    }

}