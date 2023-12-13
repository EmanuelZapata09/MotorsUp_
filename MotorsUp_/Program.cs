using Microsoft.EntityFrameworkCore;
using MotorsUp_.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<tallerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));


///

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(10);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

///

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

app.UseSession();

app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// void ConfiguarVariable(IServiceCollection services)
//{
//    services.Configure<CookiePolicyOptions>(options =>
//    {
//        options.CheckConsentNeeded = context => true;
//        options.MinimumSameSitePolicy = SameSiteMode.None;
//    });

//    services.AddDistributedMemoryCache();
//    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
//    services.AddSession(options =>
//    {
//        options.IdleTimeout = TimeSpan.FromSeconds(10);
//        options.Cookie.HttpOnly = true;
//        options.Cookie.IsEssential = true;
//    });
//}

// void Configurar(IApplicationBuilder app, IHostingEnvironment env)
//{
//    if (env.IsDevelopment())
//    {
//        app.UseDeveloperExceptionPage();
//    }
//    else
//    {
//        app.UseExceptionHandler("Home/Error");
//        app.UseHsts();
//    }

    
//    app.UseSession();
//    app.UseHttpsRedirection();
//    app.UseStaticFiles();
//    app.UseCookiePolicy();

//    app.UseMvc(routes =>
//    {
//        routes.MapRoute(
//            name: "default",
//            template: "{controller=Home}/{action=Index}/{id?}");
//    });
//}

//void ConfigureServices(IServiceCollection services)
//{

//    services.AddSession(options =>
//    {
//        // Set a short timeout for easy testing.
//        options.IdleTimeout = TimeSpan.FromSeconds(10);
//        options.Cookie.HttpOnly = true;
//        // Make the session cookie essential
//        options.Cookie.IsEssential = true;
//    });

//}



app.Run();