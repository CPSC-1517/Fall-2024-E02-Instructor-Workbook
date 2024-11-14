using Microsoft.EntityFrameworkCore;
using WestWindLibrary.DAL;
using WestWindLibrary.BLL;
using WestWindWeb.Components;
using WestWindLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Extension Registration of Services - Using the Extension
//var connectionString = builder.Configuration.GetConnectionString("WWDB");

//builder.Services.WestWindExtensionServices(options => options.UseSqlServer(connectionString));

//Registering Services directly in Program.cs
//Injecting Services must comes before the builder is built!!
builder.Services.AddDbContext<WestWindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WWDB")));

//Each services needs to be registered to be used!
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<CategoryServices>();
builder.Services.AddScoped<SupplierServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
