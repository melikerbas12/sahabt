using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahaBT.Shared;

namespace SahaBT.Core.EntityFramework.Mappings
{
    public class LessonMap : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(b => b.LessonCode).HasMaxLength(20);
        }
    }
}
