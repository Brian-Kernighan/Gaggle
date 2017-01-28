using GaggleService.Gaggle;
using GaggleService.Gaggle.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{
    public static void Main(string[] args)
    {
        //todo: Implement some args intelligent parser

        var cancellationTokenSource = new CancellationTokenSource();

        switch (GetGaggleCommand(args))
        {
            case GaggleCommand.None:
                {
                    throw new NotImplementedException();
                }

            case GaggleCommand.Start:
                {
                    Task.Factory.StartNew(cts =>
                    {
                        GaggleEngine.Start(new GaggleSettings
                        {
                            DatabaseName = "Gaggle",
                            ListenEndpoint = "@tcp://localhost:5555",
                            ConnectionString = "mongodb://localhost:27017",
                        }, (CancellationTokenSource)cts);
                    }, cancellationTokenSource);
                }
                break;
        }

        Console.WriteLine("PRESS ANY KEY TO CLOSE APPLICATION!");

        Console.ReadKey(true);

        cancellationTokenSource.Cancel();

        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
    }

    private static GaggleCommand GetGaggleCommand(string[] args)
    {
        return GaggleCommand.Start;
    }
}