using Microsoft.EntityFrameworkCore;
using homework_CodeFirst.Models;

namespace homework_CodeFirst.context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentProfile> StudentProfiles { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<StudentCourse> StudentCourse { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EFcore1;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Student>()
        .HasMany(s => s.Courses)
        .WithMany(c => c.Students)
        .UsingEntity<StudentCourse>();

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.Email)
                      .IsRequired(); 
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(s => s.Email)
                      .IsRequired();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.Name)
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasCheckConstraint("CK_Course_Price", "Price >= 0");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(l => l.Title)
                      .HasMaxLength(150);
            });

        }
    }
}
