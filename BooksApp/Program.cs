using BooksApp.DAL.Data;
using Microsoft.EntityFrameworkCore;
using BooksApp.DAL.Repository;
using BooksApp.BLL.Interfaces;
using BooksApp.Domain.Entities;
using BooksApp.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEducationalBooksRepository, EducationalBooksRepository>();
builder.Services.AddScoped<IFictionBooksRepository, FictionBooksRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IBooksService<EducationalBook>, EducationalBooksService>();
builder.Services.AddScoped<IBooksService<FictionBook>, FictionBookService>();

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
    pattern: "{controller=FictionBooks}/{action=Index}/{id?}");

app.Run();
