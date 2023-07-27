using CalisanTakipSistemi.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);



// DbContext yapýlandýrmasý için servisleri ekle
builder.Services.AddDbContext<CalisanTakipSistemiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();