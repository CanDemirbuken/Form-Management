using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WA_FormManagement.Core.Domain.Entities;
using WA_FormManagement.Core.Domain.Mappings;

namespace WA_FormManagement.Infrastructure.ApplicationDbContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new FormConfiguration());
            builder.ApplyConfiguration(new FormFieldConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
        }
    }
}
