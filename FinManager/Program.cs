using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinManager.Data;
using FinManager.Controllers;
using FinManager.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FinManagerContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("FinManagerContext"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("FinManagerContext")), builder =>
    builder.MigrationsAssembly("FinManager")));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DoerService>();
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddScoped<IncomeService>();
builder.Services.AddTransient<SeedingService>();

var app = builder.Build();

SeedData(app);
//Seed Data
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedingService>();
        service.Seed();
    }
}

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
