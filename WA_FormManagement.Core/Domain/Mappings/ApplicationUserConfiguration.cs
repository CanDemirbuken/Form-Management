using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.Core.Domain.Mappings
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.Surname).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(50).IsRequired();

            builder.HasMany(u => u.Forms)
                   .WithOne(f => f.ApplicationUser)
                   .HasForeignKey(f => f.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
