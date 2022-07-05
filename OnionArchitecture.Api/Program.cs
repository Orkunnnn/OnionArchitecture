using System.Text.Json;
using Azure.Identity;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OnionArchitecture.Api.HealthCheck;
using OnionArchitecture.Api.Middlewares;
using OnionArchitecture.Api.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Configuration.AddAzureKeyVault(new(builder.Configuration["KeyVault:VaultUri"]), new DefaultAzureCredential());
builder.Services.AddApiRegistrations(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var response = new HealthCheckResponse
        {
            Status = report.Status.ToString(),
            Checks = report.Entries.Select(x => new HealthCheck
            {
                Component = x.Key,
                Status = x.Value.Status.ToString(),
                Description = x.Value.Description
            }),
            Duration = report.TotalDuration
        };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
});
app.UseHttpsRedirection();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
