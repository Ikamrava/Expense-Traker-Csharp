using Expense_Traker_Csharp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationDbContext>();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2V1hhQlJAfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5UdkFiWH9Xc3NVRmhU");

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.UseCors(options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(origin => true);
    });



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
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
