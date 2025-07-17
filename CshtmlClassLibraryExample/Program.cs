using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(options =>
{
    // Used to enable run-time compilation for the razor class library views.
    // If removed run-time compilation will only be available for the main project.
    if (builder.Environment.IsDevelopment())
    {
        var path = Path.Combine(
            builder.Environment.ContentRootPath,
            "../SharedViews");
        var fileProvider = new PhysicalFileProvider(path);
        options.FileProviders.Add(fileProvider);
    }
});
builder.Services.AddScoped<HelloWorldService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
