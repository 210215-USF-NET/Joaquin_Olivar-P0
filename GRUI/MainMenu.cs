using GRModels;
using System;
namespace GRUI
{
    public class MainMenu : IMenu
    {
        public string linebreak = "------------------------";
        public MainMenu()
        {
            //TODO: Figure out why I need this? I mean it still runs without it but...
        }

        public void Start()
        {
            Boolean stay = true;
            do
            {
                //Opening menu
                Console.WriteLine("Welcome to Gud Records Music Store.");
                Console.WriteLine("[0] Buy vinyl");
                Console.WriteLine("[1] Donate vinyl");
                Console.WriteLine("[2] Leave.");
                Console.WriteLine("Enter a number bro.");

                //Get user input
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        Console.WriteLine("Function not yet available. Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case "1":
                        DonateRecord();
                        break;
                    case "2":
                        stay = false;
                        Console.WriteLine("Bye.");
                        break;
                    default:
                        Console.WriteLine("What? That's not an option bro. Pick again.");
                        Console.WriteLine(linebreak);
                        break;
                }

            } while(stay);
        }
        public void DonateRecord()
        {
            //New record creation
            Record newRecord = new Record();
            Console.WriteLine("What's the album name?");
            newRecord.RecordName = Console.ReadLine();
            Console.WriteLine("Who's the artist?");
            newRecord.Artist = Console.ReadLine();
            Console.WriteLine("What's the genre?");
            newRecord.GenreType = Enum.Parse<Genre>(Console.ReadLine());
            Console.WriteLine("What's the format?");
            newRecord.daFormat = Enum.Parse<Format>(Console.ReadLine());
            Console.WriteLine("What's the condition?");
            newRecord.daCondition = Enum.Parse<Condition>(Console.ReadLine());
            Console.WriteLine("How much?");
            newRecord.Price = float.Parse(Console.ReadLine());


            //Outputs vinyl information
            Console.WriteLine("Album donated.");
            Console.WriteLine(linebreak);
            Console.WriteLine("Album: " + newRecord.RecordName);
            Console.WriteLine("Artist: " + newRecord.Artist);
            Console.WriteLine("Genre: " + newRecord.GenreType);
            Console.WriteLine("Format: " + newRecord.daFormat);
            Console.WriteLine("Condition: " + newRecord.daCondition);
            Console.WriteLine("Price sold: $" + newRecord.Price);
            Console.WriteLine(linebreak);
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}