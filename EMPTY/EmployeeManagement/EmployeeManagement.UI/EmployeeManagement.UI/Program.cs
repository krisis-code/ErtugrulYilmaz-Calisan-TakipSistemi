using EmployeeManagement.BusinesEngine.Contracts;
using EmployeeManagement.BusinesEngine.Implementaion;
using EmployeeManagement.Common.Mappings;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.Contracts.DataContext;
using EmployeeManagement.Data.Implementaion;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EmployeeManagement.Data.DbModels;
using EmployeeManagement.Common.ConstantModels;
using Microsoft.AspNet.Identity;

var builder = WebApplication.CreateBuilder(args);



// DbContext yap�land�rmas� i�in servisleri ekle
builder.Services.AddDbContext<EmployeeManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<EmployeeManagementContext>();
builder.Services.AddAutoMapper(typeof(Maps));
//builder.Services.AddScoped<IEmployeeLeaveAllocationRepository, EmployeeLeaveAllocationRepository>();
//builder.Services.AddScoped<IEmployeeLeaveRequestRepository, EmployeeLeaveRequestRepository>();
//builder.Services.AddScoped<IEmployeeLeaveTypeRepository, EmployeeLeaveTypeRepository>();
builder.Services.AddScoped<IEmployeeLeaveTypeBusinessEngine, EmployeeLeaveTypeBusinessEngine>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSession();
/*uilder.Services.AddDefaultIdentity<Employee>().AddEntityFrameworkStores<EmployeeManagementContext>();*/

var app = builder.Build();

// Configure the HTTP request pipeline.


    app.UseHttpsRedirection();
    app.UseStaticFiles();
    
    app.UseRouting();

    app.UseAuthorization();
    app.UseSession();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();


app.Run();