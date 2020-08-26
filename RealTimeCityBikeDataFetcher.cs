using System;
using System.Threading.Tasks;
using System.Net.Http;

public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    private static readonly HttpClient _client = new HttpClient();

    public Task<int> GetBikeCountInStation(string stationName)
    {
        throw new NotImplementedException();
    }

    static async Task RequestUrl()
    {
        try 
        {
            HttpResponseMessage response = await _client.GetAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch(HttpRequestException exception)
        {
            Console.WriteLine("\nException Caught nibba!");
            Console.WriteLine("Message :{0}", exception.Message);
        }
    }

}