using Microsoft.EntityFrameworkCore;
using Data.Contexts; // Ensure this namespace includes your DataContext
using Services.CustomerService;
using Data.Repository;
using Data.Services.Interfaces;
using Services.ProjectService;
using Data.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the DbContext with a scoped lifetime and connection string from appsettings.json
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString); // Ensure your connection string is loaded correctly
});

// Register services with the correct lifetime
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<IProjectRepository,ProjectRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
