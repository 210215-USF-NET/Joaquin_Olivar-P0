using System;
using GRModels;
using GRBL;
using GRDL;
using System.Collections.Generic;

namespace GRUI
{
    public class ManagerMenu : IMenu
    {
        private I_GRBiz _GRBL;
        public ManagerMenu(I_GRBiz GRBL)
        {
            _GRBL = GRBL;
        }
        public void Start()
        {
            Boolean stay = true;
            do
            {
                Console.WriteLine("Hello manager.");
                Console.WriteLine("[0] Add record to inventory.");
                Console.WriteLine("[1] View all customers.");
                Console.WriteLine("[2] Search customer.");
                Console.WriteLine("[3] View store inventories.");
                Console.WriteLine("[4] Log out.");
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
                    SearchCustomers();
                    break;
                    case "3":
                    GetRecords();
                    break;
                    case "4":
                    stay = false;
                    Console.WriteLine("Logged out. Returning you to main menu...");
                    Console.WriteLine(MainMenu.linebreak);
                    break;
                }

            } while(stay);
        }
        public void AddRecord()
        {
            Boolean stay = true;
            do
            {                
                
                Console.WriteLine("Choose location: ");
                Console.WriteLine("[0] Philadelphia, PA");
                Console.WriteLine("[1] New York City, NY");
                Console.WriteLine("[2] Go back.");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
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
                    newRecord.RecID = RNG.numb.Next(1010,2000);
                    //Sends information to the BL
                    _GRBL.AddPhillyRecord(newRecord);
                    Console.WriteLine("How many copies are we adding?");
                    int newQuan = Int32.Parse(Console.ReadLine());
                    //Adding record to Philadelphia inventory
                    _GRBL.AddToInventory(100, newRecord.RecID, newQuan);
                    //Writes back vinyl information
                    Console.WriteLine("Album added to inventory:");
                    Console.WriteLine(MainMenu.linebreak);
                    Console.WriteLine(newRecord.ToString());
                    Console.WriteLine(MainMenu.linebreak);
                    Console.WriteLine(MainMenu.presskey);
                    Console.ReadLine();
                    stay = false;
                    break;
                    case "1":
                    Record newRecord1 = new Record();  
                    Console.WriteLine("What's the album name?");
                    newRecord1.RecordName = Console.ReadLine();
                    Console.WriteLine("Who's the artist?");
                    newRecord1.Artist = Console.ReadLine();
                    Console.WriteLine("What's the genre?");
                    newRecord1.GenreType = Enum.Parse<Genre>(Console.ReadLine());
                    Console.WriteLine("What's the format?");
                    newRecord1.daFormat = Enum.Parse<Format>(Console.ReadLine());
                    Console.WriteLine("What's the condition?");
                    newRecord1.daCondition = Enum.Parse<Condition>(Console.ReadLine());
                    Console.WriteLine("How much?");
                    newRecord1.Price = float.Parse(Console.ReadLine());
                    newRecord1.RecID = RNG.numb.Next(1010,2000);

                    //Sends information to the BL
                    _GRBL.AddNYCRecord(newRecord1);
                    Console.WriteLine("How many copies are we adding?");
                    int newQuan1 = Int32.Parse(Console.ReadLine());
                    //Adding record to New York inventory
                    _GRBL.AddToInventory(200, newRecord1.RecID, newQuan1);

                    //Writes back vinyl information
                    Console.WriteLine("Album added to inventory:");
                    Console.WriteLine(MainMenu.linebreak);
                    Console.WriteLine(newRecord1.ToString());
                    Console.WriteLine(MainMenu.linebreak);
                    Console.WriteLine(MainMenu.presskey);
                    Console.ReadLine();
                    stay = false;
                    break;
                    case "2":
                    stay = false;
                    break;
                }
            } while(stay);
        }
        public void GetRecords()
        {
        Boolean stay = true;
        do
            {
                Console.WriteLine("Choose location: ");
                Console.WriteLine("[0] Philadelphia, PA");
                Console.WriteLine("[1] New York City, NY");
                Console.WriteLine("[2] Go back.");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                    Console.WriteLine($"Here's what's in stock: \n{MainMenu.linebreak}");
                    List<Inventory> phillyInventory = _GRBL.GetInventory(100);
                    foreach (Inventory i in phillyInventory)
                    {
                        Record iR = _GRBL.SearchRecordByID(i.RecID);
                        Console.WriteLine(iR.ToString());
                        Console.WriteLine(MainMenu.linebreak);
                    }
                    Console.WriteLine(MainMenu.presskey);
                    Console.ReadLine();
                    stay = false;
                    break;
                    case "1":
                    Console.WriteLine($"Here's what's in stock: \n{MainMenu.linebreak}");
                    List<Inventory> nyInventory = _GRBL.GetInventory(200);
                    foreach (var i in nyInventory)
                    {
                        Record iR = _GRBL.SearchRecordByID(i.RecID);
                        Console.WriteLine(iR.ToString());
                        Console.WriteLine(MainMenu.linebreak);
                    }
                    Console.WriteLine(MainMenu.presskey);
                    Console.ReadLine();
                    stay = false;
                    break;
                    case "2":
                    stay = false;
                    break;
                }
            } while(stay);
        }        
        public void GetCustomers()
        {
            Console.WriteLine($"Customer List: \n{MainMenu.linebreak}");
            foreach (var item in _GRBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(MainMenu.linebreak);
            }
            Console.WriteLine(MainMenu.presskey);
            Console.ReadLine();
        }
        public void SearchCustomers()
        {
            Console.WriteLine("Enter customer name: ");
            Customer foundCustomer = _GRBL.SearchCustomerByFName(Console.ReadLine());
            if (foundCustomer == null)
            {
                Console.WriteLine("No customers found.");
            }
            else
            {
                Console.WriteLine(foundCustomer.ToString());
            }
        }
    }
}