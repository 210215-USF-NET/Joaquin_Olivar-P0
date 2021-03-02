using System;
using GRBL;
using GRModels;
using System.Collections.Generic;
namespace GRUI
{
    public class BuyRecordMenu : IMenu
    
    {   
        private IRecordBL _recordBL;
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL; 
        private ICartBL _cartBL;
        private I_InventoryBL _inventoryBL;

        public BuyRecordMenu(IRecordBL recordBL, ICustomerBL customerBL, ILocationBL locationBL, ICartBL cartBL, I_InventoryBL inventoryBL)
        {
            _recordBL = recordBL;
            _customerBL = customerBL;
            _locationBL = locationBL;
            _cartBL = cartBL;
            _inventoryBL = inventoryBL;
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
            else
            {
                Console.WriteLine("Customer ID: " + buyer.CustomerID);
            }
            //Select location
            Console.WriteLine("Only Phildelphia location available right now.");
            LocationClass location = new LocationClass();
            location = _locationBL.GetThisLocation(100);
            Console.WriteLine(location.ToString());

            //New cart
            Cart newCart = new Cart();
            _cartBL.newCart(buyer.CustomerID);

            //Search inventory for items of said city (Philadelphia inventory ids are 1,2,4,5)
            List <Inventory> inventory = _inventoryBL.GetInventory();
            List<Inventory> city_inventory = new List<Inventory>();
            foreach (Inventory i in inventory)
            {
                if(i.LocID == location.localID)
                {
                    city_inventory.Add(i);
                }
            }
            Console.WriteLine(city_inventory.Count);

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