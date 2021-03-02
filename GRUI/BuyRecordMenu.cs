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
        private ICartProductsBL _cartproductsBL;
        private IOrderBL _orderBL;
        private IOrderProductsBL _orderproductsBL;

        public BuyRecordMenu(IRecordBL recordBL, ICustomerBL customerBL, ILocationBL locationBL,
        ICartBL cartBL, ICartProductsBL cartproductsBL, I_InventoryBL inventoryBL, IOrderBL orderBL,
        IOrderProductsBL orderproductsBL)
        {
            _recordBL = recordBL;
            _customerBL = customerBL;
            _locationBL = locationBL;
            _cartBL = cartBL;
            _cartproductsBL = cartproductsBL;
            _inventoryBL = inventoryBL;
            _orderBL = orderBL;
            _orderproductsBL = orderproductsBL;
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
            //New Cart

            Cart cart = _cartBL.newCart(buyer.CustomerID); //Make sure having the void method for the newCart is fine
            Console.WriteLine("New Cart:" + cart.ToString());
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
            //TODO: Actually sort records from inventory

            Console.WriteLine("Which record would you like to buy?");
            Console.WriteLine("Enter record name: ");
            Record foundRecord = _recordBL.SearchRecordByName(Console.ReadLine());
            if (foundRecord == null)
            {
                Console.WriteLine("No record found.");
            }

                Console.WriteLine(foundRecord.ToString());
                Console.WriteLine(MainMenu.linebreak);
                Console.WriteLine("How many would you like to buy?");
                int BuyerQuan = Int32.Parse(Console.ReadLine());
            CartProducts cartProducts = _cartproductsBL.AddToCartProducts(foundRecord.RecID, BuyerQuan);
            Console.WriteLine(MainMenu.linebreak);

            //Order confirmation and total
            float total = 0; //TODO: Convert prices from floats to decimal
            Console.WriteLine("Confirm order: ");
            Console.WriteLine(MainMenu.linebreak);
            List<CartProducts> cartProdList = _cartproductsBL.GetCartProducts();
            foreach(CartProducts c in cartProdList)
            {
                Record boughtRecord = _recordBL.SearchRecordByID(c.RecID);
                float subtotal = c.RecQuan * boughtRecord.Price;
                Console.WriteLine(boughtRecord.ToString());
                Console.WriteLine("Quantity: " + c.RecQuan);
                Console.WriteLine(MainMenu.linebreak);
                total = total + subtotal;
            }
            Console.WriteLine("Total: " + total);
            
            Order finalOrder = new Order();
            finalOrder.CartID = cart.CartID;
            finalOrder.Customer = buyer;
            finalOrder.CusID = buyer.CustomerID;
            finalOrder.localID = 100;
            finalOrder.OrDate = DateTime.Now;

            _orderBL.AddOrder(finalOrder);
            
            //adding orderProducts to database
            OrderProducts orderProcessed = new OrderProducts();
            orderProcessed.RecQuan = 0;
            orderProcessed.OrdID = finalOrder.OrdID;
            orderProcessed.RecID = cartProducts.RecID;
            orderProcessed.RecQuan = cartProducts.RecQuan;
            
            _orderproductsBL.addOrderProducts(orderProcessed);
            //_cartproductsBL.PurgeCartProducts()
            //_cartBL.PurgeCart(cart)
            
        }
    }

}