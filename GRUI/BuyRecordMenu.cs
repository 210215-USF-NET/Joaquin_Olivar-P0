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
                return;
            }
            else
            {
                Console.WriteLine("Customer Found!");
                Console.WriteLine(MainMenu.linebreak);
                Console.WriteLine(buyer.ToString());
                Console.WriteLine(MainMenu.linebreak);
                Console.WriteLine(MainMenu.presskey);
                Console.ReadLine();
            }
            //Select location
            Console.WriteLine("Choose location:");
            Console.WriteLine("[100] Philadelphia, PA");
            Console.WriteLine("[200] New York City, NY");
            int localWeWant = Int32.Parse(Console.ReadLine());
            if (localWeWant !=100 && localWeWant != 200)
            {
                Console.WriteLine("Not a valid location.");
                Console.WriteLine(MainMenu.presskey);
                Console.ReadLine();
                return;
            }

            Cart cart = _cartBL.newCart(buyer.CustomerID); //Cart Creation
            List <Inventory> localinventory = _inventoryBL.GetInventory(localWeWant); //Sets inventory to only have location inventory
            foreach (Inventory i in localinventory)
            {
                Record iR = _recordBL.SearchRecordByID(i.RecID);
                Console.WriteLine(iR.ToString());
                Console.WriteLine(MainMenu.linebreak);
            }
            Console.WriteLine("Which record would you like to buy?");
            Console.WriteLine("Enter record ID: ");
            int RecIDWeWant = Int32.Parse(Console.ReadLine()); 
            Record foundRecord = _recordBL.SearchRecordByID(RecIDWeWant);
            if (foundRecord == null)
            {
                Console.WriteLine("No record found.");
                return;
            }
            int recInInv = localinventory.FindIndex(x => x.RecID == RecIDWeWant);
            if (recInInv < 0)
            {
                Console.WriteLine("Record not in local inventory!");
                Console.WriteLine(MainMenu.presskey);
                Console.ReadLine();
                return;
            }

                Console.WriteLine(foundRecord.ToString());
                Console.WriteLine(MainMenu.linebreak);

            //Quantity select
                Console.WriteLine("How many would you like to buy?");
                int BuyerQuan = Int32.Parse(Console.ReadLine());

            //New cartProducts
            CartProducts cartProducts = new CartProducts();
            cartProducts.RecID = foundRecord.RecID;
            cartProducts.RecQuan = BuyerQuan;
            cartProducts.CartID = cart.CartID;
            //Add cartProducts to database
            _cartproductsBL.AddToCartProducts(cartProducts);
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
            //Reset Total
            total = 0;

            Order finalOrder = new Order();
            finalOrder.CartID = cart.CartID;
            finalOrder.Customer = buyer;
            finalOrder.CusID = buyer.CustomerID;
            finalOrder.localID = localWeWant;
            finalOrder.OrDate = DateTime.Now;

            _orderBL.AddOrder(finalOrder);
            
            //adding orderProducts to database
            
            OrderProducts orderProcessed = new OrderProducts();
            //orderProcessed.RecQuan = 0;
            orderProcessed.OrdID = finalOrder.OrdID;
            orderProcessed.RecID = cartProducts.RecID;
            orderProcessed.RecQuan = cartProducts.RecQuan;
            
            
            _orderproductsBL.addOrderProducts(orderProcessed);

            foreach(CartProducts c in cartProdList)
            {
            _cartproductsBL.PurgeCartProducts(cartProducts);
            }
            /*TODO: Implement purgecart maybe?? I have a feeling if I do this
            it's gonna break some more code, and I don't wanna do that rn.
            */
            //_cartBL.PurgeCart(cart)
            Console.WriteLine("Order bought.");
            Console.WriteLine(MainMenu.presskey);
            Console.ReadLine();
        }
    }
}