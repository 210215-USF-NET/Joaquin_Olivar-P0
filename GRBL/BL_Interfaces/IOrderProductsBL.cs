using GRModels;
using System.Collections.Generic;
namespace GRBL
{
    public interface IOrderProductsBL
    {
        void addOrderProducts(OrderProducts newOrderProducts);
        List<OrderProducts> GetOrderProductsByID(int OrderID);
    }
}