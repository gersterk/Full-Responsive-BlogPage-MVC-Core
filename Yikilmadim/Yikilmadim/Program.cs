
using DataAccesLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<Context>();

    services.AddIdentity<AppUser, AppRole>(x =>
    {
        x.Password.RequireUppercase = false;
        x.Password.RequireNonAlphanumeric = false;
    })
        .AddEntityFrameworkStores<Context>();

    services.AddControllersWithViews();
    services.AddSession();

    services.AddMvc(config =>
    {
        var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
        config.Filters.Add(new AuthorizeFilter(policy));

    });
    services.AddMvc();


    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(x =>
        {
            x.LoginPath = "/Login/Index";
        });

    

    services.ConfigureApplicationCookie(options =>
    {
        //Cookie settings
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(100);
        options.AccessDeniedPath = new PathString("/Login/AccessDenied");
        options.LoginPath = "/Login/Index/";
        options.SlidingExpiration = true;
    });

    services.AddControllersWithViews().AddFluentValidation(x =>
           x.RegisterValidatorsFromAssemblyContaining<LongValidator>());

}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1","?code ={0}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "/admin/{controller=Home}/{action=Index}/{id?}"
  );


    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();
app.UseAuthentication();


app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
