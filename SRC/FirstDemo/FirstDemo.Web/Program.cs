using Autofac;
using Autofac.Extensions.DependencyInjection;
using FirstDemo.Application;
using FirstDemo.Infrastructure;
using FirstDemo.Web;
using FirstDemo.Web.Data;
using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx,lc) => lc
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft",LogEventLevel.Warning)
.Enrich.FromLogContext()
.ReadFrom.Configuration(builder.Configuration));

try
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var migrationAssembly = Assembly.GetExecutingAssembly().FullName;

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApplicationModule());
        containerBuilder.RegisterModule(new InfrastructureModule(connectionString, migrationAssembly));
        containerBuilder.RegisterModule(new WebModule());
    });

    // Add services to the container.

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString,(m)=> m.MigrationsAssembly(migrationAssembly)));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();
    builder.Services.AddSingleton<FirstDemo.Web.Models.IEmailSender, HtmlEmailSender>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
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
       name: "areas",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    app.Run();
    Log.Information("Application Starting ...");
}
catch(Exception ex)
{
    Log.Fatal(ex, "Failed to start application");
}
finally
{
    Log.CloseAndFlush();
}