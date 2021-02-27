using System;

namespace GRUI
{
    public class ManagerMenu : IMenu
    {
        public void Start()
        {
            Boolean stay = true;
            do
            {
                Console.WriteLine("Hello manager.");
                Console.WriteLine("[0] Add record to inventory.");
                Console.WriteLine("[1] Log out.");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                    Console.WriteLine("Function testing");
                    break;
                    case "1":
                    stay = false;
                    Console.WriteLine("Good bye!");
                    break;
                }

            }
            while(stay);
        }
    }
}