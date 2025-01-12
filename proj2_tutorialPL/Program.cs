using proj2_tutorialPL;
using proj2_tutorialPL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using proj2_tutorialPL.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja us�ugi IWarehouseService z odpowiedni� implementacj�
builder.Services.AddScoped<IWarehouseService, IWarehouseService>();

// Konfiguracja DbContext z u�yciem UseSqlServer
builder.Services.AddDbContext<DbTestContext>(options =>
	options.UseSqlServer(@"Data Source=DESKTOP-RV5HS5R\MSSQLSERVER2022;Initial Catalog=DbTest;Integrated Security=True")
);

// Konfiguracja Identity z poprawn� konfiguracj� i obs�ug� DbTestContext
builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
{
	options.Password.RequireDigit = false;
	options.Password.RequiredLength = 4;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireLowercase = false;
})
	.AddEntityFrameworkStores<DbTestContext>()
	.AddDefaultTokenProviders();
// Dodaj MVC lub inne us�ugi
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Konfiguracja potoku HTTP
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
