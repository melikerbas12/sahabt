using Microsoft.EntityFrameworkCore;
using SahaBT.Core.EntityFramework.Mappings;
using SahaBT.Shared;

namespace SahaBT.Core.EntityFramework.DatabaseContext
{
    public class SahaBTContext : DbContext
    {
        public SahaBTContext(DbContextOptions<SahaBTContext> options) : base(options)
        {

        }
        #region Tables
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new LessonMap());
            modelBuilder.ApplyConfiguration(new StudentLessonMap());
        }
    }
}
