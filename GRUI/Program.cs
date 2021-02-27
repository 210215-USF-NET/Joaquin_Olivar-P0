using GRBL;
using GRDL;
using Serilog;
using Serilog.Formatting.Compact;

namespace GRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Basic menu test.
            IMenu menu = new MainMenu(new RecordBL(new RecordRepoFile()),new CustomerBL(new CustomerRepoFile()));
            menu.Start();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(new CompactJsonFormatter(), "./Logs/logs.json")
                .CreateLogger();
                Log.Information("Successfully ran project.");
        }
    }
}
