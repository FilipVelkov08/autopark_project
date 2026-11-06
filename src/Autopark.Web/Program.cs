using Autopark.Data;
using Autopark.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Базата данни: EF Core + SQL Server. Connection string-ът се чете от конфигурацията.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Липсва connection string 'DefaultConnection'.");

builder.Services.AddDbContext<AutoparkDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Identity: вход, регистрация, роли. Пазим потребителите в нашата база.
builder.Services
    .AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Lockout.MaxFailedAccessAttempts = 5;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AutoparkDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // нужни за готовите страници за вход/регистрация

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // кой е потребителят
app.UseAuthorization();  // какво има право да прави

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
    .WithStaticAssets();

app.Run();
