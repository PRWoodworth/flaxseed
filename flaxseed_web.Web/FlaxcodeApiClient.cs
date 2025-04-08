using System.Text.Json;
using System.Text.RegularExpressions;
using flaxseed_web.Web.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace flaxseed_web.Web;
public class FlaxcodeApiClient(HttpClient httpClient)
{
    public async Task<FlaxcodeModel> GetFlaxcodeAsync(FlaxcodeModel flaxcode_object)
    {
        try
        {
            var request_content_serialized = JsonSerializer.Serialize(flaxcode_object.FlaxcodeInputString);
            var response = await httpClient.PostAsJsonAsync("/getflaxcode", request_content_serialized);
            var generated_flaxcode = await response.Content.ReadAsStringAsync();

            var regex = new Regex("data:image/(.*);base64,");
            generated_flaxcode = (String)regex.Replace(generated_flaxcode, "");
            flaxcode_object.FlaxcodeOutput = (Image<Rgba32>)Image.Load(Convert.FromBase64String(generated_flaxcode));


        }
        catch (Exception)
        {

            throw;
        }
        
        
        return flaxcode_object;
    }
}

