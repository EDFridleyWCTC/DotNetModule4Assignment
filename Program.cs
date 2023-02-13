namespace Module4Assignment;
using NLog;
class Program
{
    static void Main(string[] args)
    {

        // See https://aka.ms/new-console-template for more information
        string path = Directory.GetCurrentDirectory() + "\\nlog.config";

        var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

        

    }
}
