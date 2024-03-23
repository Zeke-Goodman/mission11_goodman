using Microsoft.EntityFrameworkCore;
using mission11_goodman.Models; // Importing necessary models

var builder = WebApplication.CreateBuilder(args); // Creating a web application builder

// Add services to the container.
builder.Services.AddControllersWithViews(); // Adding controllers and views services to the container

// Adding database context to the services with SQLite as the provider
builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookConnection"]); // Using SQLite connection string from configuration
});

// Registering the EFBookRepository as a scoped service
builder.Services.AddScoped<IBookRepository, EFBookRepository>();

var app = builder.Build(); // Building the application

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Handling errors in production
    app.UseExceptionHandler("/Home/Error");

    // Enforcing HTTPS in production
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirecting HTTP requests to HTTPS
app.UseStaticFiles(); // Serving static files

app.UseRouting(); // Configuring routing

app.UseAuthorization(); // Adding authorization middleware

// Configuring default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Running the application
