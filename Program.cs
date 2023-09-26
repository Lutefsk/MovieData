// See https://aka.ms/new-console-template for more information
using NLog;
string path = Directory.GetCurrentDirectory() + "\\nlog.config";
// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

bool optionISNOT1or2 = true;
while (optionISNOT1or2)
{
    Console.WriteLine("Enter 1 to view movies file");
    Console.WriteLine("Enter 2 to add a movie to the file.");
    Console.WriteLine("Enter anything else to quit.");

    // input response
    string resp = Console.ReadLine();
    int maxid = 0;

    if (resp == "1") //read the movies.csv file
    {
        string filePath = Directory.GetCurrentDirectory() + "\\movies.csv";
        if (File.Exists(filePath))
        {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] segments = line.Split(',');
                Console.WriteLine($"{segments[0]}, {segments[1]}, {segments[2]}"); // display each movie attribute on one line


                if (int.TryParse(segments[0], out int id))
                {
                    maxid = Math.Max(maxid, id);
                }
                else
                {
                    logger.Warn("invalid ID in movies.csv file, file correct id number");
                }
            }

        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }
    }

    else if (resp == "2") //append to the movies.csv file
    {
        Console.WriteLine("Enter the movie id, Title (year), Genre|Genres of the movie:");
        string newMovie = Console.ReadLine();

        //add entry to movies.csv
        string filePath = Directory.GetCurrentDirectory() + "\\movies.csv";
        StreamWriter sw = new StreamWriter(filePath, true);
        {
            sw.WriteLine(newMovie);

        }
        sw.Close();
    }
    else
    {
        optionISNOT1or2 = false;
    }
}

