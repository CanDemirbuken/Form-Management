using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WA_FormManagement.Core.Domain.Entities;
using WA_FormManagement.Core.Domain.RepositoryContracts;
using WA_FormManagement.Core.ServiceContracts;
using WA_FormManagement.Core.Services;
using WA_FormManagement.Infrastructure.ApplicationDbContext;
using WA_FormManagement.Infrastructure.Repositories;
using WA_FormManagement.Infrastructure.RepositoryContracts;

namespace WA_FormManagement.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppDb"), options => options.MigrationsAssembly("WA_FormManagement.Infrastructure")));
            services.AddControllersWithViews();

            services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;

                // Sign-in settings
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormFieldRepository, FormFieldRepository>();
            services.AddScoped<IFormsService, FormsService>();
            services.AddScoped<IFormFieldsService, FormFieldsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}