using GRModels;
using System.Collections.Generic;
namespace GRBL
{
    public interface IOrderBL
    {
        void AddOrder(Order order);
        List<Order> GetOrdersByID(int CustomerID);
    }
}