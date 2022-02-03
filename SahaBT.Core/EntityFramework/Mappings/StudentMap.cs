using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahaBT.Shared;

namespace SahaBT.Core.EntityFramework.Mappings
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(b => b.Name).HasMaxLength(50);
            builder.Property(b => b.Age).HasMaxLength(20);
        }
    }
}
