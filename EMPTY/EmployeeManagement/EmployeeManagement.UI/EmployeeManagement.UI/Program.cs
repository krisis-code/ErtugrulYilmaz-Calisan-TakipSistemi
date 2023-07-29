using EmployeeManagement.Common.Mappings;
using EmployeeManagement.Data.Contracts.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// DbContext yapýlandýrmasý için servisleri ekle
builder.Services.AddDbContext<EmployeeManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
builder.Services.AddAutoMapper(typeof(Maps));
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();