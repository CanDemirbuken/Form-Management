using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.Core.Domain.Mappings
{
    public class FormFieldConfiguration : IEntityTypeConfiguration<FormField>
    {
        public void Configure(EntityTypeBuilder<FormField> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DataType).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Form)
                .WithMany(x => x.Fields)
                .HasForeignKey(x => x.FormId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
