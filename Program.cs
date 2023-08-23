using GoogleSolution.Models.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PhotoHome.Data;
using PhotoHome.Models.Entity;
using System.ComponentModel;
using System.Configuration;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();
//builder.Services.AddIdentity<Company, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//.AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/LogIn";
    options.AccessDeniedPath = "/User/LogIn";
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//
var container = app.Services.CreateScope();
var userManager = container.ServiceProvider.GetRequiredService<UserManager<User>>();
var roleManager = container.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

if (!await roleManager.RoleExistsAsync("Admin"))
{
    var result = await roleManager.CreateAsync(new IdentityRole("Admin"));
    if (!result.Succeeded) throw new Exception(result.Errors.First().Description);
}

var user = await userManager.FindByEmailAsync("admin@gmail.com");

if (user == null)
{
    user = new User
    {
        UserName = "admin@gmail.com",
        Email = "admin@gmail.com",
        FirstName = "Admin",
        LastName = "Admin",
        EmailConfirmed = true
    };

    var result = await userManager.CreateAsync(user, "aA1!1111");

    if (!result.Succeeded)
        throw new Exception(result.Errors.First().Description);

    result = await userManager.AddToRoleAsync(user, "Admin");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Notification}/{action=Index}/{id?}"
    );
	endpoints.MapDefaultControllerRoute();
});

app.Run();