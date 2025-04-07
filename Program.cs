using Microsoft.EntityFrameworkCore;
using MyMvcExamProject.Models;  // Models ad alanını dahil et


var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısını ekleyin
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC'yi ekleyin
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Uygulama pipeline'ı
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Exam}/{action=Index}/{id?}");

app.Run();
