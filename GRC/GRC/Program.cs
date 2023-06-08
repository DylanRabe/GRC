//Apres L'infra on configure les dependences
//quand on a finit on defini dans appsettings
using GRC.Domain;
using GRC.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GRC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container. c'est Ici
        string ConnectionString = builder.Configuration.GetConnectionString("GRC");
        //builder.Services.AddDbContext<GrcContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GRC")));
        builder.Services.AddInfrastructure(ConnectionString);
        builder.Services.AddControllersWithViews();



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
            pattern: "{controller=GRC}/{action=Index}/{id?}");

        app.Run();
    }
}