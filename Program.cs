using System;
using System.Threading.Tasks;

class Program {
    static async Task Main (string[] args) {
#if true
        RealTimeCityBikeDataFetcher dataFetcher = new RealTimeCityBikeDataFetcher ();
        try {
            Console.WriteLine (args[0]);
            await dataFetcher.GetBikeCountInStation (args[0]);
        } finally {
            Console.WriteLine ("Terminating....");
        }
#endif

#if false
        OfflineCityBikeDataFetcher dataFetcher = new OfflineCityBikeDataFetcher ();
        try {
            Console.WriteLine (args[0]);
            await dataFetcher.GetBikeCountInStation (args[0]);
        } finally {
            Console.WriteLine ("Terminating....");
        }
#endif
    }
}