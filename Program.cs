using Poweroff.Controllers;
using Serilog;

namespace Poweroff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            NetworkListener listener = new(8000);

            listener.StartAsync();

            Console.ReadLine();

            Log.CloseAndFlush();
        }
    }
}
