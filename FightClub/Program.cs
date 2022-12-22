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
app.MapControllerRoute(name: "default", pattern: "{controller=Post}/{action=PostWall}/{id?}");

app.Run();
