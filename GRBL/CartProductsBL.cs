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
        public void AddToCartProducts(CartProducts cartProducts)
        {
            _repo.AddToCartProducts(cartProducts);
        }

        public List<CartProducts> GetCartProducts()
        {
            return _repo.GetCartProducts();
        }

        public void PurgeCartProducts(CartProducts cartProductsforDeletion)
        {
            _repo.PurgeCartProducts(cartProductsforDeletion);
        }
    }
}