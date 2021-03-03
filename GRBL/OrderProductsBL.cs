using System.Collections.Generic;
using GRDL;
using GRModels;

namespace GRBL
{
    public class OrderProductsBL : IOrderProductsBL
    {
        private IOrderProductsRepo _repo;
        public OrderProductsBL(IOrderProductsRepo repo)
        {
            _repo = repo;
        }
        public void addOrderProducts(OrderProducts newOrderProducts)
        {
            _repo.AddOrderProducts(newOrderProducts);
        }

        public List<OrderProducts> GetOrderProductsByID(int OrderID)
        {
            return _repo.GetOrderProductsByID(OrderID);
        }
    }
}