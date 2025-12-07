using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tabula.Data;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = true
    ).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
    options.LoginPath = "/Account/Index" // Login Redirection
);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Middleware Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
