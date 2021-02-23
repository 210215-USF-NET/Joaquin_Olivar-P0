using GRModels;
using System;
using GRBL;
namespace GRUI
{
    public class MainMenu : IMenu
    {
        private IRecordBL _recordBL;
        
        public MainMenu(IRecordBL recordBL)
        {
            _recordBL = recordBL;
        }

        public string linebreak = "------------------------";
        public void Start()
        {
            Boolean stay = true;
            do
            {
                //Opening menu
                Console.WriteLine("Welcome to Gud Records Music Store.");
                Console.WriteLine("[0] Create an account.");
                Console.WriteLine("[1] Donate album.");
                Console.WriteLine("[2] Get records.");
                Console.WriteLine("[3] Leave.");
                Console.WriteLine("Enter a number bro.");

                //Get user input
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        CreateAccount();
                        break;
                    case "1":
                        DonateRecord();
                        break;
                    case "2":
                        GetRecords();
                        break;
                    case "3":
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
        public void CreateAccount()
        {
            //Creating a new customer.
            Customer newCustomer = new Customer();
            Console.WriteLine("Oh. Another music nerd. Enter your username, loser:");
            newCustomer.UserName = Console.ReadLine();
            Console.WriteLine("How original. Enter e-mail:");
            newCustomer.Email = Console.ReadLine();
            Console.WriteLine("Enter address:");
            newCustomer.Address = Console.ReadLine();
            Console.WriteLine("Enter zip code:");
            newCustomer.ZipCode = Int16.Parse(Console.ReadLine());

            //Reading back customer information.
            Console.WriteLine("New account added.");
            Console.WriteLine(linebreak);
            Console.WriteLine("Username: " + newCustomer.UserName);
            Console.WriteLine("Email: " + newCustomer.Email);
            Console.WriteLine("Address: " + newCustomer.Address);
            Console.WriteLine("Zip code: " + newCustomer.ZipCode);
            Console.WriteLine(linebreak);
            Console.WriteLine("Press any key to continue:");
            Console.ReadLine();
        }
        //----------
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

            //Sends information to the BL
            _recordBL.AddRecord(newRecord);

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
        public void GetRecords()
        {
            foreach (var item in _recordBL.GetRecords())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}