using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Data.Contracts.DataContext;
using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// DbContext konfigürasyonu
builder.Services.AddDbContext<EmployeeManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

//Kimlik doğrulama ve yetkilendirme konfigürasyonu
builder.Services.AddIdentity<Employee, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
}).AddUserManager<UserManager<Employee>>()
.AddRoleManager<RoleManager<IdentityRole>>()
   .AddEntityFrameworkStores<EmployeeManagementContext>()
    .AddDefaultTokenProviders(); // UserManager<Employee> hizmetini ekleyin

//builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<EmployeeManagementContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddAuthorization();

// Controller, Razor Pages ve Session hizmetlerini ekle
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddSession();

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
app.UseSession();

app.MapControllers();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
