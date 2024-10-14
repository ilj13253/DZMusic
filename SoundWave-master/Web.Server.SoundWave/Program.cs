using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.SoundWave.Data;
using Model.SoundWave.Entities;
using Web.Server.SoundWave;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// Add DbContext with connection string
string connection = builder.Configuration.GetConnectionString("SoundWaveDBConnectionString");
builder.Services.AddDbContext<SoundWaveDBContext>(options => options.UseSqlServer(connection));

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<SoundWaveDBContext>()
    .AddDefaultTokenProviders();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddIdentity<User,IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SoundWaveDBContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
var app = builder.Build();
await Seed.SeedUsersAndRolesAsync(app);
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
