using System;
using GRModels;
using GRBL;

namespace GRUI
{
    public class ManagerMenu : IMenu
    {
        private IRecordBL _recordBL;
        private ICustomerBL _customerBL;
        public ManagerMenu(IRecordBL recordBL, ICustomerBL customerBL)
        {
            _recordBL = recordBL;
            _customerBL = customerBL;
        }
        public void Start()
        {
            Boolean stay = true;
            do
            {
                Console.WriteLine("Hello manager.");
                Console.WriteLine("[0] Add record to inventory.");
                Console.WriteLine("[1] View customers.");
                Console.WriteLine("[2] Log out.");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                    AddRecord();
                    break;
                    case "1":
                    GetCustomers();
                    break;
                    case "2":
                    stay = false;
                    Console.WriteLine("Logged out. Returning you to main menu...");
                    Console.WriteLine(MainMenu.linebreak);
                    break;
                }

            }
            while(stay);
        }
        public void AddRecord()
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

            //Writes back vinyl information
            Console.WriteLine("Album added to inventory:");
            Console.WriteLine(MainMenu.linebreak);
            Console.WriteLine(newRecord.ToString());
            Console.WriteLine(MainMenu.linebreak);
            Console.WriteLine(MainMenu.presskey);
            Console.ReadLine();
        }
        public void GetRecords()
        {
            Console.WriteLine($"Here's what's in stock: \n{MainMenu.linebreak}");
            foreach (var item in _recordBL.GetRecords())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(MainMenu.linebreak);
            }
            Console.WriteLine(MainMenu.presskey);
            Console.ReadLine();
        }
        public void GetCustomers()
        {
            Console.WriteLine($"Customer List: \n{MainMenu.linebreak}");
            foreach (var item in _customerBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(MainMenu.linebreak);
            }
            Console.WriteLine(MainMenu.presskey);
            Console.ReadLine();
        } 
    }
}