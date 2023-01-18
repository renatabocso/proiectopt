using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopifyPlatform.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShopifyPlatformContextConnection") ?? throw new InvalidOperationException("Connection string 'ShopifyPlatformContextConnection' not found.");

builder.Services.AddDbContext<ShopifyPlatformContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ShopifyPlatformContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ShopifyPlatformEntityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopifyPlatformEntityContext") ?? throw new InvalidOperationException("Connection string 'ShopifyPlatformEntityContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
