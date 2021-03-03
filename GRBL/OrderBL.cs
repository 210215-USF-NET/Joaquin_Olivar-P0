using GRModels;
using GRDL;
using System.Collections.Generic;

namespace GRBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderRepo _repo;
        public OrderBL(IOrderRepo repo)
        {
            _repo = repo;
        }
        public void AddOrder(Order order)
        {
            _repo.AddOrder(order);
        }

        public List<Order> GetOrdersByID(int CustomerID)
        {
            return _repo.GetOrdersByID(CustomerID);
        }
    }
}