using RCBCurrency.JSON.Interfaces;
using RCBCurrency.JsonDeserialize;
using RCBCurrency.Services.Implementation;
using RCBCurrency.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ILoadJson, LoadJson>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/CurrenciesData/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CurrenciesData}/{action=Currencies}/{id?}");

app.Run();
