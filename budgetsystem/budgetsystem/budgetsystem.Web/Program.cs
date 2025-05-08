using Microsoft.EntityFrameworkCore;
using budgetsystem.Shared.Data;
using budgetsystem.Shared.Services;
using budgetsystem.Web.Components;
using budgetsystem.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// EF Core connection string (manual DB only)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddHttpContextAccessor(); // Optional if needed

// No Identity: no .AddIdentity(), no cookie configuration

builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<BudgetService>();
builder.Services.AddScoped<AppUserService>();

// Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(budgetsystem.Shared._Imports).Assembly);

app.Run();
