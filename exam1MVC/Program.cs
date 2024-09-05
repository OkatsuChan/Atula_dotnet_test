using Application.Common.Interfaces;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using exam1MVC.Services;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AddApplicationServices
builder.Services.AddApplicationServices();

// Add ApplicationDbContext to Services
builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    // Set connectionString
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseSqlServer(connectionString);
});


// Add ApplicationDbContext to Services
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

// Add ApplicationDbContextInitialiser to Services
builder.Services.AddScoped<ApplicationDbContextInitialiser>();

// Add AddDefaultIdentity to Services
builder.Services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

// Add IIdentityService to Services
builder.Services.AddTransient<IIdentityService, IdentityService>();

// Add IUser to Services
builder.Services.AddScoped<IUser, CurrentUser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

 
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // InitialiseDatabaseAsync
    await app.InitialiseDatabaseAsync();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();


