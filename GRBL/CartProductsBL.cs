using GRModels;
using GRDL;
namespace GRBL
{
    public class CartProductsBL : ICartProductsBL
    {
        private ICartProductsRepo _repo;
        public CartProductsBL(ICartProductsRepo repo)
        {
            _repo = repo;
        }
        public CartProducts AddToCartProducts(int RecID, int RecQuan)
        {
            return _repo.AddToCartProducts(RecID, RecQuan);
        }
    }
}