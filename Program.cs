using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Ba�lant� dizesini ekliyoruz
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// DbContext'e ba�lant�y� sa�l�yoruz
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Identity servislerini ekliyoruz
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true; // Kullan�c� hesab� onaylamay� zorunlu tut
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Di�er servisler
builder.Services.AddControllersWithViews();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint(); // Migration i�lemleri i�in hata ay�klama sayfas�n� etkinle�tir
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Ortak middleware yap�land�rmas�
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Identity kimlik do�rulamas�
app.UseAuthorization();  // Yetkilendirme middleware'i

// Varsay�lan rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Razor sayfalar�n� dahil eder

// Migration'lar� otomatik uygulama (opsiyonel, development i�in �nerilir)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    try
    {
        // Veritaban�n� g�ncelle
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Migration error: {ex.Message}");
    }
}

app.Run();
