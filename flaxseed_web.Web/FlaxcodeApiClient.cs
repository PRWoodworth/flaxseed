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
            String request_content = JsonSerializer.Serialize(new
            {
                body = flaxcode_object.FlaxcodeInput.ToString()
            });
            //TODO: this cannot be done as JSON as-is. Need to refactor sending end to provide compatible data or find a work-around on receiving end. 
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("/getflaxcode", request_content);
            String generated_flaxcode = await response.Content.ReadAsStringAsync();
            //Error preventing progress is exclusively on above line
            /*
             * System.InvalidOperationException: 
             * The type 'System.ReadOnlySpan`1[System.Byte]' of property 'Preamble' on type 'System.Text.Encoding' is invalid for serialization or deserialization 
             * because it is a pointer type, is a ref struct or contains generic parameters that have not been replaced by specific types.
             * */

            byte[] bytes = Convert.FromBase64String(generated_flaxcode);
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

