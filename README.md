# Cshtml file re-use example

An example of how to use ASP.NET Core MVC project views from a razor class library.

## Enabling run-time compilation

### How to enable run-time compilation for the MVC project
#### 1. Add this on the startup file
```csharp
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
```
<img width="1069" height="162" alt="image" src="https://github.com/user-attachments/assets/7dff6744-8274-4abc-bbed-6faec498d1d7" />

#### 2. Install this NuGet package on to the MVC project
```
Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
```

### How to enable run-time compilation for the razor class library
#### 1. Update MVC project startup file to include this
```csharp
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
```
<img width="976" height="242" alt="image" src="https://github.com/user-attachments/assets/d5f22a2c-65e6-498b-9f8e-b4185cef8a74" />

#### 2. Install this NuGet package on to the razor class library
```
Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
```


