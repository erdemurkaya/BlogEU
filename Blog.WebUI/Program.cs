using Blog.Business.Managers;
using Blog.Business.Services;
using Blog.DAL.Abstract;
using Blog.DAL.Concrate;
using Blog.DAL.Context;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BlogDB>(options=>options.UseSqlServer(connectionString));


builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));

builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IPostService,PostManager>();

builder.Services.AddScoped<INewsService, NewsManager>();

builder.Services.AddScoped<INewsService, NewsManager>();

builder.Services.AddScoped<IMyProfileService, MyProfileManager>();

builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IAboutService, AboutManager>();





var app = builder.Build();


app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: ("{area:exists}/{Controller=Dashboard}/{Action=Index}/{id?}"));


app.MapControllerRoute(

    name: "default",
    pattern: ("{Controller=Home}/{Action=Index}/{id?}"));


app.Run();
