using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IDepartmentRepositry,DepartmentRepositry>();
builder.Services.AddScoped<IStudentRepositry,StudentRepositry>();

//add identity 
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ITIEntities>();

//Database injection
builder.Services.AddDbContext<ITIEntities>(options =>
//options.UseSqlServer("Data Source=DESKTOP-U2G078Q\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;initial Catalog=ITIFirstEntity;Multi Subnet Failover=False")
options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
);

// To add session confiuger 
builder.Services.AddSession(a => { 

a.IdleTimeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithRedirects("/Home/Error");
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
/*
app.Use(async (context, next) => {

    await context.Response.WriteAsync("1) MiddleWare 1 \n");

    await next.Invoke();

});

app.Use(async (context, next) => {

    await context.Response.WriteAsync("2) MiddleWare 2 \n");

    await next.Invoke();

});

app.Run(async (context) => {

    await context.Response.WriteAsync("3) Terminate 3 \n");
});

app.Use(async (context, next) => {

    await context.Response.WriteAsync("4) MiddleWare 4 \n");

    await next.Invoke();

});*/


app.UseHttpsRedirection();

app.UseSession();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default1",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default2",
    pattern: "Std/{id:int}",
    defaults:new {controller ="Student",action ="Index" });

app.Run();
