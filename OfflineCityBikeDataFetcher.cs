using System;
using System.IO;
using System.Threading.Tasks;

public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher {

    public async Task<int> GetBikeCountInStation (string stationName) {
        await ParseTextFile ();
        return 0;
    }

    static async Task ParseTextFile () {
        try {
            using (StreamReader reader = new StreamReader ("bikedata.txt")) {
                string line;
                while ((line = reader.ReadLine ()) != null)
                    Console.WriteLine (line);
            }
        } catch (Exception exception) {
            Console.WriteLine ("Can't read file: ");
            Console.WriteLine (exception.Message);
        }
    }

    static string GetFileText (string name) {
        string fileContents = String.Empty;

        if (File.Exists (name)) {
            fileContents = File.ReadAllText (name);
        }
        return fileContents;
    }
}