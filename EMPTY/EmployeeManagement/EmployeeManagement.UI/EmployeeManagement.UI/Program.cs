using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Data.Contracts.DataContext;
using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext konfigürasyonu
builder.Services.AddDbContext<EmployeeManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

// Kimlik doğrulama ve yetkilendirme konfigürasyonu
builder.Services.AddIdentity<Employee, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<EmployeeManagementContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddAuthorization();

// Controller, Razor Pages ve Session hizmetlerini ekle
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddSession(); // Session hizmetini ekledik

// Diğer servisler

var app = builder.Build();

// Veritabanı migrasyonu
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<EmployeeManagementContext>();
    dbContext.Database.Migrate();

    // Seed data
    var userManager = services.GetRequiredService<UserManager<Employee>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    SeedData.Seed(userManager, roleManager);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession(); // Session kullanımını ekledik

// Controller, Razor Pages ve Session endpoint'lerini ekle
app.MapControllers();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
