using Microsoft.EntityFrameworkCore;
using Test_Invoice.Common.interfaces;
using Test_Invoice.Infrastructure.DbContextConfig;
using Test_Invoice.Infrastructure.Repository;
using Test_Invoice.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TestInvoiceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Test_Invoice"));
});

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddTransient<ICustomerType, CustomerTypeRepository>();
builder.Services.AddTransient<IInvoice, InvoiceRepository>();
builder.Services.AddTransient<IInvoiceDetail, InvoiceDetailRepository>();

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