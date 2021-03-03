using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    public interface IOrderRepo
    {
        void AddOrder(Order order);
        List<Order> GetOrdersByID(int CustomerID);
    }
}