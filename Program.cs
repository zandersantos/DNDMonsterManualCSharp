using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DungeonsAndDragonsMonsterManualCSharp.Data;
using DungeonsAndDragonsMonsterManualCSharp.Models;
using Microsoft.AspNetCore.Identity;
using DungeonsAndDragonsMonsterManualCSharp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DungeonsAndDragonsMonsterManualCSharpContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DungeonsAndDragonsMonsterManualCSharpContext") ?? throw new InvalidOperationException("Connection string 'DungeonsAndDragonsMonsterManualCSharpContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Identity Services
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DungeonsAndDragonsMonsterManualCSharpContext>();

//To make the Password Policy to be the bare minimum. This is for testing purposes
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6; // Minimum length
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();


