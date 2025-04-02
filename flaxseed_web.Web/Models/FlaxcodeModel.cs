namespace flaxseed_web.Web.Models;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
public class FlaxcodeModel
{
    public string FlaxcodeInput { get; set; }
    public Image<Rgba32> FlaxcodeOutput { get; set; }
    public FlaxcodeModel(string input) { FlaxcodeInput = input; }
    public FlaxcodeModel( ) { }
}
