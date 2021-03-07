using GRModels;
using System;
using GRBL;
using System.Collections.Generic;

namespace GRUI
{
    public class ViewOrderHistoryMenu : IMenu
    {  private I_GRBiz _biz;
        public ViewOrderHistoryMenu(I_GRBiz biz)
        {
            _biz = biz;
        }
        public void Start()
        {
            Console.WriteLine("Please enter your customer ID: ");
            int ID = Int32.Parse(Console.ReadLine());
            Customer customer = _biz.SearchCustomerByID(ID);
            Console.WriteLine(customer.ToString());
            Console.WriteLine(MainMenu.linebreak);
            //Create list with order ID's
            List<Order> orderlist =_biz.GetOrdersByID(ID);
            Console.WriteLine("Order list: ");
            foreach (Order o in orderlist)
            {
                Console.WriteLine(o.ToString());
                List<OrderProducts> opl =_biz.GetOrderProductsByID(o.OrdID);
                Console.WriteLine(MainMenu.linebreak);
                foreach (OrderProducts op in opl)
                {
                    Console.WriteLine(op.ToString());
                    Record opR = _biz.SearchRecordByID(op.RecID);
                    Console.WriteLine(opR.ToString());
                }
            }
            Console.WriteLine(MainMenu.linebreak);
            Console.WriteLine(MainMenu.presskey);
            Console.ReadLine();
        }
    }
}