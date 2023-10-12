using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Database;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => // https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-7.0
{
    o.AddDefaultPolicy(policy =>
    {
        policy.WithMethods("POST", "PUT", "GET", "OPTIONS");
        policy.WithOrigins("https://localhost:5173");
        //policy.AllowAnyOrigin();
        //policy.AllowAnyHeader();
    });
});


builder.Services.AddDbContext<PhotoContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PhotoContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PhotoContext, PhotoContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Photo}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
