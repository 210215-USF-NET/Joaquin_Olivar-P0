using GRModels;
using Model = GRModels;
using System;
using GRBL;
using GRDL;
namespace GRUI
{
    public class MainMenu : IMenu
    {
        I_GRBiz _biz;
        public MainMenu(I_GRBiz biz)
        {
            _biz = biz;
        }

        public static string linebreak = "------------------------";
        public static string presskey = "Press any key to continue.";
        public void Start()
        {
            Boolean stay = true;
            do
            {
                //Opening menu
                Console.WriteLine("Welcome to Gud Records Music Store!");
                Console.WriteLine("Please pick an option:");
                Console.WriteLine("[0] Create an account.");
                Console.WriteLine("[1] Buy a record.");
                Console.WriteLine("[2] Get customer order(s).");
                Console.WriteLine("[3] View store inventories.");
                Console.WriteLine("[4] Search inventory.");
                Console.WriteLine("[5] Manager login.");
                Console.WriteLine("[6] Leave.");

                //Get user input
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        CreateAccount();
                        break;
                    case "1":
                        IMenu buymenu = new BuyRecordMenu(_biz);
                        buymenu.Start();
                        break;
                    case "2":
                        IMenu searchmenu = new ViewOrderHistoryMenu(_biz);
                        searchmenu.Start();
                        break;
                    case "3":
                        GetRecords();
                        break;
                    case "4":
                        SearchRecords();
                        break;
                    case "5":
                        Console.WriteLine("Enter username: ");
                        if(Console.ReadLine() == Manager.userName)
                        {
                            Console.WriteLine("Enter password: ");
                            if(Console.ReadLine() == Manager.passWord)
                            {
                                IMenu adminmenu = new ManagerMenu(_biz);
                                adminmenu.Start();
                            }
                            else
                            {
                                Console.WriteLine("Incorrect password.");
                                Console.WriteLine(presskey);
                                Console.ReadLine();
                                break;
                            }
                        }
                        else
                        {
                        Console.WriteLine("Incorrect username.");
                        Console.WriteLine(presskey);
                        Console.ReadLine();
                        }
                        break;
                    case "6":
                        stay = false;
                        Console.WriteLine("Thank you for shopping at Gud Records!");
                        break;
                    
                    default:
                        Console.WriteLine("Not a valid option. Try again.");
                        Console.WriteLine(linebreak);
                        break;
                }

            } while(stay);
        }
        public void CreateAccount()
        {
            //Creating a new customer.
            Model.Customer newCustomer = new Model.Customer();
            Console.WriteLine("Please enter your first name:");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Please enter e-mail:");
            newCustomer.Email = Console.ReadLine();
            Console.WriteLine("Enter address:");
            newCustomer.Address = Console.ReadLine();
            Console.WriteLine("Enter zip code:");
            newCustomer.ZipCode = Int32.Parse(Console.ReadLine());
            newCustomer.CustomerID = RNG.numb.Next(1,1001);

            //Reading back customer information.
            Console.WriteLine(linebreak);
            _biz.AddCustomer(newCustomer);
            Console.WriteLine("New account added.");
            Console.WriteLine(newCustomer.ToString());
            Console.WriteLine(linebreak);
            Console.WriteLine(presskey);
            Console.ReadLine();
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
                Console.WriteLine($"Here's what's in stock: \n{linebreak}");
                foreach (var item in _biz.GetPhillyRecords())
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(linebreak);
                }
                Console.WriteLine(presskey);
                Console.ReadLine();
                stay = false;
                break;
                case "1":
                Console.WriteLine($"Here's what's in stock: \n{linebreak}");
                foreach (var item in _biz.GetNYCRecords())
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(linebreak);
                }
                Console.WriteLine(presskey);
                Console.ReadLine();
                stay = false;
                break;
                case "2":
                stay = false;
                break;
            }
        } while(stay);
        }
        public void SearchRecords()
        {
            Console.WriteLine("Enter record name: ");
            Model.Record foundRecord = _biz.SearchRecordByName(Console.ReadLine());
            if (foundRecord == null)
            {
                Console.WriteLine("No record found.");
            }
            else
            {
                Console.WriteLine(foundRecord.ToString());
            }
        }
    }
}