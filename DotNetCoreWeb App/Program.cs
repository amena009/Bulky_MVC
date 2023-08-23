using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using BulkyMVCWebApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//whatever we'll add in service container , it is DI
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//since we don't need CategoryRepository, coz now we are using UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//1.register our DbContext class
//2.here we'll tell DbContext options to UseSqlServer
//3.we'll pass the connection string of particular DB
//whenever we ask for implementation of DbContext, do the below config and give the object
builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) );

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
