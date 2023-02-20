﻿namespace Module4Assignment;
using NLog;
class Program
{
    static int increment = -1;
    static void Main(string[] args)
    {

        string path = Directory.GetCurrentDirectory() + "\\nlog.config";
        string moviesPath = Directory.GetCurrentDirectory() +"\\ml-latest-small\\movies.csv";

        var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

        Console.WriteLine(NextId(moviesPath));
        Menu(moviesPath);
    }

    static void Menu(string moviesPath) {
        string input = "";
        do {
            Console.WriteLine(GetMenuText());
            Console.Write("Please select an option from above: ");
            input = Console.ReadLine();
            switch (input) {
                case "1":
                    ReadMovies(moviesPath);
                    break;
                case "2":
                    Console.WriteLine("Enter a max limit: ");
                    int i = 0;
                    Int32.TryParse(Console.ReadLine(), out i);
                    if (i <= 0) {
                        Console.WriteLine("Not a valid input. Any key to continue...");
                        Console.ReadLine();
                        break;
                    }
                    ReadMovies(moviesPath, i);
                    break;
                case "3":
                    WriteMovie(AddMovie());
                    break;
                case "X":
                    return;
                default:
                    continue;
            }
        } while (input.ToUpper() != "X");
    }

    static string GetMenuText() {
        return "Movie Library:\n\n1) See all movies\n2) See a certain number of movies\n3) Add a movie\nX) Exit";
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

    static String AddMovie() {

        return "";
    }

    static void WriteMovie(string line) {

    }

    static int NextId(string moviesPath) {

        if (increment < 0) {
            StreamReader sr = new StreamReader(moviesPath);
            
            int maxId = 0;
            while (!sr.EndOfStream) {
                string line = sr.ReadLine();
                int lineId = 0;
                Int32.TryParse(line.Split(',')[0], out lineId);
                if (lineId > maxId) {
                    maxId = lineId;
                }
            }
            sr.Close();
            increment = maxId + 1;  
        }
        return increment++;
    }
}
