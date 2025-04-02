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
            Image<Rgba32> generatedFlaxcode = new(1, 1);
            await foreach (var flaxcode in httpClient.GetFromJsonAsAsyncEnumerable<Image<Rgba32>>("/getflaxcode", cancellationToken))
            {
                if (flaxcode != null)
                {
                    generatedFlaxcode = flaxcode;
                }
            }
            flaxcode_object.FlaxcodeOutput = generatedFlaxcode;
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

