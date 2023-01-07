using Npgsql;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using EntityFramework;
using EntityFramework.Entity;
using DataModel.Interfaces;
using DataModel.Models.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddTransient<IRepositoryContext, ContextEntityFramework>();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddDbContext<IdentityApplicationDbContext>();
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityApplicationDbContext>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(name: "AllChats", pattern: "Chats/", defaults: new { controller = "Chat", action = "AllChats" });

app.MapControllerRoute(name: "CreateChat", pattern: "{controller}/Create", defaults: new { controller = "Chat", action = "CreateChat" });
app.MapControllerRoute(name: "CreatePost", pattern: "{controller}/Create", defaults: new { controller = "Post", action = "CreatePost" });
app.MapControllerRoute(name: "EditChat", pattern: "{controller}/Edit/", defaults: new { controller = "Chat", action = "EditChat" });
app.MapControllerRoute(name: "EditPost", pattern: "{controller}/Edit/", defaults: new { controller = "Post", action = "EditPost" });

app.MapControllerRoute(name: "PostWall", pattern: "{action}/", defaults: new { controller = "Post", action = "PostWall" });
app.MapControllerRoute(name: "PostAction", pattern: "PostWall/{action}", defaults: new { controller = "Post" });

app.MapControllerRoute(name: "default", pattern: "{controller=Post}/{action=PostWall}/{id?}");

app.Run();
