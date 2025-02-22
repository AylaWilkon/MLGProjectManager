using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Services.CustomerService;
using Data.Repository;
using Data.Services.Interfaces;
using Services.ProjectService;
using Data.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

//H�r har chat gpt anv�nds som r�dverktyg f�r att kolla upp hur man l�gger till
//scoped klass med interface i services, med syfte att uppn� dependency injection kravet.
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<IProjectRepository,ProjectRepository>();

var app = builder.Build();

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
