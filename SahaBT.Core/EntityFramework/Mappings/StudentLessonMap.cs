using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahaBT.Shared;

namespace SahaBT.Core.EntityFramework.Mappings
{
    public class StudentLessonMap :IEntityTypeConfiguration<StudentLesson>
    {
        public void Configure(EntityTypeBuilder<StudentLesson> builder)
        {
            builder.HasKey(sl => new { sl.StudentId, sl.LessonId });

            builder
                .HasOne<Student>(sl => sl.Student)
                .WithMany(s => s.StudentLessons)
                .HasForeignKey(sl => sl.StudentId);


            builder
                .HasOne<Lesson>(sl => sl.Lesson)
                .WithMany(l => l.StudentLessons)
                .HasForeignKey(sl => sl.LessonId);
        }
    }
}
