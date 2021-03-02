using GRModels;
using GRDL;
namespace GRBL
{
    public class CartBL : ICartBL
    {
        private ICartRepo _repo;
        public CartBL(ICartRepo repo)
        {
            _repo = repo;
        }
        public Cart newCart(Cart newCart)
        {
            return _repo.NewCart(newCart);
        }
    }
}