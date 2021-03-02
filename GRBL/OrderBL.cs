using GRModels;
using GRDL;
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
    }
}