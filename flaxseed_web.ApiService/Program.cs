using flaxseed_web.ApiService;
using SixLabors.ImageSharp;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapPost("/getflaxcode", ([FromBody]String flaxcode_input) =>
{
    var deserialized_input = JsonSerializer.Deserialize<String>(flaxcode_input);
    Image <Rgba32> output = FlaxcodeGeneration.Generate_Flaxcode(deserialized_input);
    String base64output = output.ToBase64String(PngFormat.Instance);
    return base64output;
})
.WithName("GetFlaxcode");

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}