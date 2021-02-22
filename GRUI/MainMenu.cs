using GRModels;
using System;
namespace GRUI
{
    public class MainMenu : IMenu
    {
        public MainMenu()
        {
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
                        Console.WriteLine("Function not yet available.");
                        break;
                    case "1":
                        DonateVinyl();
                        break;
                    case "2":
                        stay = false;
                        Console.WriteLine("Bye.");
                        break;
                    default:
                        Console.WriteLine("What?");
                        break;
                }

            } while(stay);
        }
        public void DonateVinyl()
        {
            //New vinyl creation
            Vinyl newVinyl = new Vinyl();
            Console.WriteLine("What's the album name?");
            newVinyl.VinylName = Console.ReadLine();
            Console.WriteLine("Who's the artist?");
            newVinyl.Artist = Console.ReadLine();
            Console.WriteLine("What's the genre?");
            newVinyl.GenreType = Enum.Parse<Genre>(Console.ReadLine());
            Console.WriteLine("What's the condition?");
            newVinyl.daCondition = Enum.Parse<Condition>(Console.ReadLine());
            Console.WriteLine("How much?");
            newVinyl.price = float.Parse(Console.ReadLine());

            //Outputs vinyl information
            Console.WriteLine("Album donated.");
            Console.WriteLine("Album: " + newVinyl.VinylName);
            Console.WriteLine("Artist: " + newVinyl.Artist);
            Console.WriteLine("Genre: " + newVinyl.GenreType);
            Console.WriteLine("Condition: " + newVinyl.daCondition);
            Console.WriteLine("Price sold: $" + newVinyl.price);

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}