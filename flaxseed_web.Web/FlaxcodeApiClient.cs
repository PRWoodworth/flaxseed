using flaxseed_web.Web.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace flaxseed_web.Web;
public class FlaxcodeApiClient(HttpClient httpClient)
{
    public async Task<FlaxcodeModel> GetFlaxcodeAsync(FlaxcodeModel flaxcode_object, CancellationToken cancellationToken = default)
    {
        try
        {
            //TODO: this cannot be done as JSON as-is. Need to refactor sending end to provide compatible data or find a work-around on receiving end. 
            String generated_flaxcode = await httpClient.GetStringAsync("/getflaxcode", cancellationToken);
        //Error preventing progress is exclusively on above line
        //TODO: this isn't actually sending a request body i think. i should probably fix that. 
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

    record Flaxcode(Image<Rgba32> Generated_flaxcode)
    {
        //TODO
    }
}

