using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.Core.Domain.Mappings
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FormName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
            .IsRequired();

            builder.HasOne(x => x.ApplicationUser)
                .WithMany(x => x.Forms)
                .HasForeignKey(x => x.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Fields)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
