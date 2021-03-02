using System;
using GRBL;
using GRModels;
namespace GRUI
{
    public class BuyRecordMenu : IMenu
    
    { private IRecordBL _recordBL;
        private ICustomerBL _customerBL; 
        public BuyRecordMenu(IRecordBL recordBL, ICustomerBL customerBL)
        {
            _recordBL = recordBL;
            _customerBL = customerBL;
        }
        public void Start()
        {
            Console.WriteLine("Which record would you like to buy?");
            Console.WriteLine("Enter record name: ");
            Record foundRecord = _recordBL.SearchRecordByName(Console.ReadLine());
            if (foundRecord == null)
            {
                Console.WriteLine("No record found.");
            }
            else
            {
                Console.WriteLine(foundRecord.ToString());
                Console.WriteLine("Add to cart?");
            }
        }
    }
}