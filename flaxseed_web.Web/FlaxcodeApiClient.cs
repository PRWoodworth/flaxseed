using System.Net.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace flaxseed_web.Web
{
    public class FlaxcodeApiClient(HttpClient httpClient)
    {
        public async Task<Image<Rgba32>> GetFlaxcodeAsync(CancellationToken cancellationToken = default)
        {
            Image<Rgba32> generated_flaxcode = new(1,1);
            await foreach (var flaxcode in httpClient.GetFromJsonAsAsyncEnumerable< Image < Rgba32 >>("/getflaxcode", cancellationToken))
            {
                if (flaxcode is not null)
                {
                    generated_flaxcode = flaxcode;
                }
            }
            return generated_flaxcode;
        }
    }
}

