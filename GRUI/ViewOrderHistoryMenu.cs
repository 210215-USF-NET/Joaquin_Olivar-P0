using GRModels;
using System;
using GRBL;
using System.Collections.Generic;

namespace GRUI
{
    public class ViewOrderHistoryMenu : IMenu
    {  private IRecordBL _recordBL;
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL; 
        private ICartBL _cartBL;
        private I_InventoryBL _inventoryBL;
        private ICartProductsBL _cartproductsBL;
        private IOrderBL _orderBL;
        private IOrderProductsBL _orderproductsBL;

        public ViewOrderHistoryMenu(IRecordBL recordBL, ICustomerBL customerBL, ILocationBL locationBL,
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
            Console.WriteLine("Please enter your customer ID: ");
            int ID = Int32.Parse(Console.ReadLine());
            Customer customer = _customerBL.SearchCustomerByID(ID);
            Console.WriteLine(customer.ToString());
            Console.WriteLine(MainMenu.linebreak);
            //Create list with order ID's
            List<Order> orderlist =_orderBL.GetOrdersByID(ID);
            Console.WriteLine("Order list: ");
            foreach (Order o in orderlist)
            {
                Console.WriteLine(o.ToString());
                List<OrderProducts> opl =_orderproductsBL.GetOrderProductsByID(o.OrdID);
                Console.WriteLine(MainMenu.linebreak);
                foreach (OrderProducts op in opl)
                {
                    Console.WriteLine(op.ToString());
                    Record opR = _recordBL.SearchRecordByID(op.RecID);
                    Console.WriteLine(opR.ToString());
                }
            }
            Console.WriteLine(MainMenu.linebreak);
            Console.WriteLine(MainMenu.presskey);
            Console.ReadLine();
        }
    }
}