using System.Text.Json;
using flaxseed_web.ApiService;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;


var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapPost("/getflaxcode", ([FromBody] String flaxcode_input) =>
{
    var deserialized_input = JsonSerializer.Deserialize<String>(flaxcode_input);
    Image<Rgba32> output = FlaxcodeGeneration.Generate_Flaxcode(deserialized_input);
    String base64output = output.ToBase64String(PngFormat.Instance);
    return base64output;
})
.WithName("GetFlaxcode");

app.MapDefaultEndpoints();

app.Run();