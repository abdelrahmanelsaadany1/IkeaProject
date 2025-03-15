using Microsoft.EntityFrameworkCore;
using Ikea.DAL.Presistance.Data;
using Ikea.DAL.Presistance.Repositories.Departments;
using Ikea.BLL.Services.Departments;
using Ikea.DAL.Presistance.Repositories.Employees;
using Ikea.BLL.Services.Employees;
namespace Ikea.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Configure Service

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>((
                options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); }




            ) );
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
