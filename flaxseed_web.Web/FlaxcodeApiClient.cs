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
            flaxcode_object.FlaxcodeBase64 = await response.Content.ReadAsStringAsync();
        }
        catch (Exception)
        {

            throw;
        }
        
        
        return flaxcode_object;
    }
}

