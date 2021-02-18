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
                Console.WriteLine("Yo guy. What you want?");
                Console.WriteLine("[1] Buy vinyl");
                Console.WriteLine("[2] Donate vinyl");
                Console.WriteLine("[3] Gtfo.");
                Console.WriteLine("Enter a number bro.");

                //Get user input
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        Console.WriteLine("Function not yet available.");
                        break;
                    case "2":
                        Console.WriteLine("Dis ain't work either.");
                        break;
                    case "3":
                        stay = false;
                        Console.WriteLine("Get the hell outta here.");
                        break;
                    default:
                        Console.WriteLine("...bro. Wtf you doin'?");
                        break;
                }

            } while(stay);
        }
    }
}