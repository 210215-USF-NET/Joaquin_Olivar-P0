using GRModels;
using System;
using GRBL;
using GRDL;
namespace GRUI
{
    public class MainMenu : IMenu
    {
        private IRecordBL _recordBL;
        private ICustomerBL _customerBL; 
        public MainMenu(IRecordBL recordBL, ICustomerBL customerBL)
        {
            _recordBL = recordBL;
            _customerBL = customerBL;
        }

        public static string linebreak = "------------------------";
        public static string presskey = "Press any key to continue";
        public void Start()
        {
            Boolean stay = true;
            do
            {
                //Opening menu
                Console.WriteLine("Welcome to Gud Records Music Store!");
                Console.WriteLine("Please pick an option:");
                Console.WriteLine("[0] Create an account.");
                Console.WriteLine("[1] Customer list.");;
                Console.WriteLine("[2] View inventory.");
                Console.WriteLine("[3] Manager login.");
                Console.WriteLine("[4] Leave.");

                //Get user input
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        CreateAccount();
                        break;
                    case "1":
                        GetCustomers();
                        break;
                    case "2":
                        GetRecords();
                        break;
                    case "3":
                        Console.WriteLine("Enter username: ");
                        if(Console.ReadLine() == Manager.userName)
                        {
                            Console.WriteLine("Enter password: ");
                            if(Console.ReadLine() == Manager.passWord)
                            {
                                IMenu adminmenu = new ManagerMenu(new RecordBL(new RecordRepoFile()),new CustomerBL(new CustomerRepoFile()));
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
                    case "4":
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
            Customer newCustomer = new Customer();
            Console.WriteLine("Please enter your first name:");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Please enter e-mail:");
            newCustomer.Email = Console.ReadLine();
            Console.WriteLine("Enter address:");
            newCustomer.Address = Console.ReadLine();
            Console.WriteLine("Enter zip code:");
            newCustomer.ZipCode = Int16.Parse(Console.ReadLine());

            //Reading back customer information.
            _customerBL.AddCustomer(newCustomer);
            Console.WriteLine("New account added.");
            Console.WriteLine(newCustomer.ToString());
        }
        public void GetCustomers()
        {
            foreach (var item in _customerBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(linebreak);
            }
            Console.WriteLine(presskey);
            Console.ReadLine();
        } 
        public void GetRecords()
        {
            foreach (var item in _recordBL.GetRecords())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(linebreak);
            }
            Console.WriteLine(presskey);
            Console.ReadLine();
        }
    }
}