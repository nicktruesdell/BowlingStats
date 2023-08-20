using System.Configuration;
using Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".BowlingStats.Session";
    options.Cookie.IsEssential = true;

});
builder.Services.AddAutoMapper(typeof(Program));
string connectionString = builder.Configuration.GetConnectionString("BowlingDb");
builder.Services.AddDbContext<IBowlingContext, BowlingContext>(options => options.UseSqlServer(connectionString));

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

using (var scope = app.Services.CreateScope())
{
    using (var db = (BowlingContext)scope.ServiceProvider.GetService<IBowlingContext>())
    {
        db.Database.Migrate();
    }
}

app.UseSession();

app.Run();
