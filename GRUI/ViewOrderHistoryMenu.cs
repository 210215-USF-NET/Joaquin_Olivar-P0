using GRModels;
using System;
using GRBL;

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
            Console.WriteLine("Test message.");
        }
    }
}