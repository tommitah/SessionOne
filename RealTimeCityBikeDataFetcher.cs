using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    private static readonly HttpClient _client = new HttpClient();

    private static BikeRentalStationList bikeRentalStationList;

    public async Task<int> GetBikeCountInStation(string stationName)
    {
        if (stationName.Any(char.IsDigit))
            throw new ArgumentException(String.Format("Cannot contain numbers."));

        await RequestUrl();
        foreach (var station in bikeRentalStationList.Stations)
        {
            if (stationName == station.name)
            {
                Console.WriteLine("Bikes available: " + station.bikesAvailable);
                return station.bikesAvailable;
            }
        }
        throw new NotfoundException(String.Format("Can't find station: " + stationName));
    }

    static async Task RequestUrl()
    {
        try
        {
            string responseBody = await _client.GetStringAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
            bikeRentalStationList = JsonConvert.DeserializeObject<BikeRentalStationList>(responseBody);
        }
        catch (HttpRequestException exception)
        {
            Console.WriteLine("\nException Caught brother!");
            Console.WriteLine("Message :{0}", exception.Message);
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}