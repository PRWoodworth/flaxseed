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
            FlaxcodeModel generated_flaxcode = await httpClient.GetFromJsonAsync<FlaxcodeModel>("/getflaxcode", cancellationToken: cancellationToken);
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

