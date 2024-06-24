using BussinessObject.Model;
using FUGoodsExchange.Security;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton(typeof(IReportService), typeof(ReportService));
builder.Services.AddSingleton(typeof(IProductService), typeof(ProductService));
builder.Services.AddSingleton(typeof(IUserService), typeof(UserService));


builder.Services.AddSingleton(typeof(IReportRepository), typeof(ReportRepository));
builder.Services.AddSingleton(typeof(IProductRepository), typeof(ProductRepository));
builder.Services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));

builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddDbContext<FugoodexchangeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register repositories and services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<PasswordHasher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.Run();
