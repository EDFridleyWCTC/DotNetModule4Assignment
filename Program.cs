namespace Module4Assignment;
using NLog;
class Program
{
    static void Main(string[] args)
    {

        // See https://aka.ms/new-console-template for more information
        string path = Directory.GetCurrentDirectory() + "\\nlog.config";
        string moviesPath = Directory.GetCurrentDirectory() +"\\ml-latest-small\\movies.csv";

        var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

        ReadMovies(moviesPath, 50);

    }

    static void ReadMovies(string path) {
        StreamReader sr = new StreamReader(path);
        
        while (!sr.EndOfStream) {
            string line = sr.ReadLine();
            PrintMovie(line);
        }
        sr.Close();
    }

    static void ReadMovies(string path, int max) {
        StreamReader sr = new StreamReader(path);
        
        int counter = 0;
        while (!sr.EndOfStream && counter < max) {
            string line = sr.ReadLine();
            PrintMovie(line);
            counter++;
        }
        sr.Close();
    }
    
    static void PrintMovie(string line) {
        string[] lineItems = line.Split(',');
        Console.WriteLine($"Movie ID: {lineItems[0]}");
        Console.Write($"Title: {lineItems[1]}");
        if (lineItems.Length == 4) {
            Console.Write("," + lineItems[2]);
        }
        Console.WriteLine();
        Console.WriteLine($"Genre: {lineItems[lineItems.Length - 1].Replace("|", ", ")}");
        Console.WriteLine();
    }
}
