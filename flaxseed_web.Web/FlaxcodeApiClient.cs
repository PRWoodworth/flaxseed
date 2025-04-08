using System.Text.Json;
using flaxseed_web.Web.Models;
using SixLabors.ImageSharp;
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
            var bytes = Convert.FromBase64String(generated_flaxcode);
            //System.FormatException: The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.
            Image<Rgba32> image;
            using (MemoryStream ms = new(bytes))
            {
                image = (Image<Rgba32>)Image.Load(ms);
            }

            flaxcode_object.FlaxcodeOutput = image;
        }
        catch (Exception)
        {

            throw;
        }
        
        
        return flaxcode_object;
    }
}

