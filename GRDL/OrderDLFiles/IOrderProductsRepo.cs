using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    public interface IOrderProductsRepo
    {
        void AddOrderProducts(OrderProducts orderProducts);
        List<OrderProducts> GetOrderProductsByID(int OrderID);
    }
}