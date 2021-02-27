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
                Console.WriteLine("[1] Log out.");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                    DonateRecord();
                    break;
                    case "1":
                    stay = false;
                    Console.WriteLine("Good bye!");
                    Console.WriteLine(MainMenu.presskey);
                    Console.ReadLine();
                    break;
                }

            }
            while(stay);
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

            //Sends information to the BL
            _recordBL.AddRecord(newRecord);

            //Outputs vinyl information
            Console.WriteLine("Album donated.");
            Console.WriteLine(MainMenu.linebreak);
            Console.WriteLine(newRecord.ToString());
            Console.WriteLine(MainMenu.linebreak);
            Console.WriteLine(MainMenu.presskey);
            Console.ReadLine();
        }
    }
}