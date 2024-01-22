using FactuSystem.Data;
using FactuSystem.Data.Context;
using FactuSystem.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
builder.Services.AddScoped<IFacturaServices,FacturaServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var serviceScope =  app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider
        .GetRequiredService<MyDbContext>();
}

app.Run();
