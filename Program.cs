using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Services;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IStoreService, StoreService>();


            builder.Services.AddDbContext<DbStoreContext>(builder =>
            {
                builder.UseSqlServer("Data Source=mssql2.webio.pl,2401;Database=triageadmin_miododstaniula;Uid=triageadmin_miododstaniula;Password=Opel1234@;TrustServerCertificate=True");
            });

            var app = builder.Build();
            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}