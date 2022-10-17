using Luke_n_Phil_Dog_Show.Data;
using Luke_n_Phil_Dog_Show.Helpers;
using Luke_n_Phil_Dog_Show.Interfaces;
using Luke_n_Phil_Dog_Show.Models;
using Luke_n_Phil_Dog_Show.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// configure sql server to ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(e =>
e.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// configure identity framework to use AppUser for the user system
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
    opt.Lockout.MaxFailedAccessAttempts = 5;
});
// additional services
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMailgunSenderEmail, MailgunSenderEmail>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("Mailgun"));



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
