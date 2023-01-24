using Microsoft.EntityFrameworkCore;
using MyCoolApp.Data;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? builder.Environment.EnvironmentName;

    builder.Configuration
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
           .AddJsonFile("blah.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"blah.{environmentName}.json", optional: true, reloadOnChange: true);

    builder.Services.AddControllersWithViews();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    // To use scoped css while running the app in Debug mode for environments other than Development
    builder.WebHost.UseStaticWebAssets();

    // Register other services here

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
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

// Make the implicit Program class public so test projects can access it. I got this from Microsoft docs: - AshishK
// https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0#basic-tests-with-the-default-webapplicationfactory
public partial class Program { }
