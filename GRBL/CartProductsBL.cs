using GRModels;
using GRDL;
using System.Collections.Generic;

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

        public List<CartProducts> GetCartProducts()
        {
            return _repo.GetCartProducts();
        }
    }
}