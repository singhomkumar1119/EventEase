using EventEase.Components;
using EventEase.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Components with interactive server-side rendering.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// State-management service for user sessions (scoped per browser circuit).
builder.Services.AddScoped<UserSessionService>();

// In-memory "database" of events, shared across the app.
builder.Services.AddSingleton<EventEase.Services.EventRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Custom error handler instead of the default developer exception page.
    // Fixes an early routing bug where unhandled exceptions crashed navigation.
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
