namespace flaxseed_web.Web.Models;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

[JsonDerivedType(typeof(FlaxcodeModel), typeDiscriminator: "base")]

public class FlaxcodeModel
{
    [BindProperty]
    public string FlaxcodeInputString { get; set; }
    [BindProperty]
    public string FlaxcodeBase64 { get; set; }
    public FlaxcodeModel(string input) { FlaxcodeInputString = input; }
    public FlaxcodeModel( ) { }
}
