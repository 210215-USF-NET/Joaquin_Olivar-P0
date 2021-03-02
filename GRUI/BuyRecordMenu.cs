using System;
using GRBL;
using GRModels;
namespace GRUI
{
    public class BuyRecordMenu : IMenu
    
    {   
        private IRecordBL _recordBL;
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL; 
        private ICartBL _cartBL;

        public BuyRecordMenu(IRecordBL recordBL, ICustomerBL customerBL, ILocationBL locationBL, ICartBL cartBL)
        {
            _recordBL = recordBL;
            _customerBL = customerBL;
            _locationBL = locationBL;
            _cartBL = cartBL;
        }
        public void Start()
        {   
            //Select customer
            Console.WriteLine("Enter customer name: ");
            Customer buyer = _customerBL.SearchCustomerByFName(Console.ReadLine());
            if (buyer == null)
            {
                Console.WriteLine("No customers found.");
            }
            //Select location
            Console.WriteLine("Only Phildelphia location available right now.");
            LocationClass location = new LocationClass();
            location = _locationBL.GetThisLocation(100);
            Console.WriteLine(location.ToString());

            //New cart
            Cart newCart = new Cart();
            _cartBL.newCart(newCart);

            /*Console.WriteLine("Which record would you like to buy?");
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
            }*/
        }
    }
}