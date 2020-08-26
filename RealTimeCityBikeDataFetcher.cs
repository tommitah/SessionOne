using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    private static readonly HttpClient _client = new HttpClient();

    private static BikeRentalStationList bikeRentalStationList;

    public async Task<int> GetBikeCountInStation(string stationName)
    {
        foreach (var station in bikeRentalStationList.Stations)
        {
            if (stationName == station.name)
            {
                Console.WriteLine("Bikes available: " + station.bikesAvailable);
                return station.bikesAvailable;
            }
        }
        return 0;
    }

    static async Task RequestUrl()
    {
        try
        {
            HttpResponseMessage response = await _client.GetAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseBody);
            bikeRentalStationList = JsonConvert.DeserializeObject<BikeRentalStationList>(responseBody);
        }
        catch (HttpRequestException exception)
        {
            Console.WriteLine("\nException Caught nibba!");
            Console.WriteLine("Message :{0}", exception.Message);
        }
    }

}