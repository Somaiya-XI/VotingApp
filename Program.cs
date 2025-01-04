var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

#pragma warning disable ASP0014
// Use the endpoint routing middleware
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "{Area:exists}/{controller=Home}/{action=Index}");
    // endpoints.MapControllerRoute(
    //     name: "blog",
    //     pattern: "blog/{*article}",
    //     defaults: new { controller = "Blog", action = "Article" });
    // endpoints.MapControllerRoute(
    //     name: "products",
    //     pattern: "products/{category}/{id?}",
    //     defaults: new { controller = "Products", action = "Category" });
});

app.Run();
