using GRModels;
using Model = GRModels;
using System;
using GRBL;
using GRDL;
using GRDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
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
        public static string presskey = "Press any key to continue.";
        public void Start()
        {
            //Context
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

            string connectionString = configuration.GetConnectionString("RecordDB");
            DbContextOptions<GRdatabaseContext> options = new DbContextOptionsBuilder<GRdatabaseContext>()
            .UseSqlServer(connectionString).Options;

            using var context = new GRdatabaseContext(options);
            //End context
            Boolean stay = true;
            do
            {
                //Opening menu
                Console.WriteLine("Welcome to Gud Records Music Store!");
                Console.WriteLine("Please pick an option:");
                Console.WriteLine("[0] Create an account.");
                Console.WriteLine("[1] Buy a record.");
                Console.WriteLine("[2] Get customer order(s).");
                Console.WriteLine("[3] View full inventory.");
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
                        IMenu buymenu = new BuyRecordMenu(new RecordBL(new RecordRepoDB(context, new Mapper())),
                        new CustomerBL(new CustomerRepoDB(context, new Mapper())),new LocationBL(new LocationRepoDB(context, new Mapper())),
                        new CartBL(new CartRepoDB(context, new Mapper())), new CartProductsBL(new CartProductsDB(context, new Mapper())),
                        new InventoryBL(new InventoryRepoDB(context, new Mapper())), new OrderBL(new OrderRepoDB(context, new Mapper())),
                        new OrderProductsBL(new OrderProductsRepoDB(context, new Mapper())));
                        buymenu.Start();
                        break;
                    case "2":
                        IMenu searchmenu = new ViewOrderHistoryMenu(new RecordBL(new RecordRepoDB(context, new Mapper())),
                        new CustomerBL(new CustomerRepoDB(context, new Mapper())),new LocationBL(new LocationRepoDB(context, new Mapper())),
                        new CartBL(new CartRepoDB(context, new Mapper())), new CartProductsBL(new CartProductsDB(context, new Mapper())),
                        new InventoryBL(new InventoryRepoDB(context, new Mapper())), new OrderBL(new OrderRepoDB(context, new Mapper())),
                        new OrderProductsBL(new OrderProductsRepoDB(context, new Mapper())));
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
                                IMenu adminmenu = new ManagerMenu(new RecordBL(new RecordRepoDB(context, new Mapper())),
                                new CustomerBL(new CustomerRepoDB(context, new Mapper())),
                                new InventoryBL(new InventoryRepoDB(context, new Mapper())));
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

            //Reading back customer information.
            _customerBL.AddCustomer(newCustomer);
            Console.WriteLine("New account added.");
            Console.WriteLine(newCustomer.ToString());
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
                foreach (var item in _recordBL.GetPhillyRecords())
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
                foreach (var item in _recordBL.GetNYCRecords())
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
            Model.Record foundRecord = _recordBL.SearchRecordByName(Console.ReadLine());
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