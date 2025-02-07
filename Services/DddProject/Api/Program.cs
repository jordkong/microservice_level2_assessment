using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yarp.ReverseProxy;
using DddProject.Application.Services;
using DddProject.Domain.Services;
using DddProject.Infrastructure.Controllers;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add Reverse Proxy Service
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// ✅ Register Business Logic Services
builder.Services.AddScoped<IAuthenticator, Authenticator>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddControllers();

var app = builder.Build();

// ✅ Enable Routing & Reverse Proxy Middleware
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapReverseProxy();  // 🛑 This Enables YARP!
});

app.Run();
