using Microsoft.EntityFrameworkCore;
using Container_Cat.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ContainerCatContext>(
    options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("ContainerCatContext")
                ?? throw new InvalidOperationException(
                    "Connection string 'ContainerCatContext' not found."
                )
        )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add HttpClient service.
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Th
    app.UseHttpsRedirection();
}
//Database creation:
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ContainerCatContext>();
    dbContext.Database.Migrate();
    dbContext.Database.EnsureCreated();
}

/
IConfiguration config = new ConfigurationBuilder()
   
    .AddEnvironmentVariables()
    .Build();

//Get implemented container APIs:
var apiCollection = config.GetRequiredSection("ContainerApi");
ArgumentNullException.ThrowIfNull(apiCollection);



=
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
