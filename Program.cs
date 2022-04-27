using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

var builder = WebApplication.CreateBuilder(args);



string connString = "Data Source=LAPTOP-4I79REJG\\TESTINSTANCE;Initial Catalog=SwiggyTask;Integrated Security=True;TrustServerCertificate=True;";

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connString));
// Add services to the container.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
