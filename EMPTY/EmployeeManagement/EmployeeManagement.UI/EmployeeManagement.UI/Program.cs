using EmployeeManagement.BusinesEngine.Contracts;
using EmployeeManagement.BusinesEngine.Implementaion;
using EmployeeManagement.Common.Mappings;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.Contracts.DataContext;
using EmployeeManagement.Data.Implementaion;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// DbContext yapýlandýrmasý için servisleri ekle
builder.Services.AddDbContext<EmployeeManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
builder.Services.AddAutoMapper(typeof(Maps));
//builder.Services.AddScoped<IEmployeeLeaveAllocationRepository, EmployeeLeaveAllocationRepository>();
//builder.Services.AddScoped<IEmployeeLeaveRequestRepository, EmployeeLeaveRequestRepository>();
//builder.Services.AddScoped<IEmployeeLeaveTypeRepository, EmployeeLeaveTypeRepository>();
builder.Services.AddScoped<IEmployeeLeaveTypeBusinessEngine, EmployeeLeaveTypeBusinessEngine>();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

app.MapGet("/", () => "Merhaba  Worldd!");

app.Run();