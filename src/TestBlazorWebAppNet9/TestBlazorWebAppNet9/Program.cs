using Microsoft.AspNetCore.Http.Features;
using TestBlazorWebAppNet9.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.Use(async (context, next) =>
        {
            // Include this to try and catch the bug:
            bool IsOnCorrectPathBase = context.Request.Path.StartsWithSegments("/app1");
            if (!IsOnCorrectPathBase)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Not found: Pretending to be behind a proxy that only accepts the base path");
                return;
            }    
            await next(context);
        }
        );

app.UsePathBase("/app1/"); // New
app.UseRouting(); // New

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
