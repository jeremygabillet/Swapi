using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Swapi.API.Implementations
{
    public class BaseApi
    {
        protected async Task<string> CallBaseApi(string URL)
        {
            var client = new HttpClient();


            // Get the response.
            HttpResponseMessage response = await client.PostAsync(
                URL,
                null);

            // Get the response content.
            HttpContent responseContent = response.Content;

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                string json = (await reader.ReadToEndAsync());
                return json;
            }
        }
    }
}
