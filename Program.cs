using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using project.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMvc();
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(
                builder.Configuration.GetConnectionString("localDb")));

            builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlite(
                builder.Configuration.GetConnectionString("AuthApp")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = true;           // цифра
                options.Password.RequireLowercase = true;       // строчная буква
                options.Password.RequireUppercase = false;       // заглавная буква
                options.Password.RequireNonAlphanumeric = false; // спецсимвол
                options.Password.RequiredLength = 6;           // минимальная длина
                options.Password.RequiredUniqueChars = 0;      // количество уникальных символов
                options.SignIn.RequireConfirmedEmail = false;
            })
            .AddEntityFrameworkStores<AuthDbContext>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Home",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "Miniatures",
                pattern: "{controller=Miniatures}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
