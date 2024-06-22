using Film.Data.Abstract;
using Film.Data.Concrete;
using Film.Data.Concrete.EfCore;
using Film.Data.Concrete.EntityFrameworkCore;
using Film.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieDbConnection"]);
});
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<IMovieRepository, EfMovieRepository>();
var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}"
     );
app.Run();
