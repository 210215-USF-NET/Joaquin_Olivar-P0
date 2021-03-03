using GRModels;
using System.Collections.Generic;
namespace GRBL
{
    public interface ICartProductsBL
    {
        void AddToCartProducts(CartProducts cartProducts);
        List<CartProducts> GetCartProducts();

        void PurgeCartProducts(CartProducts cartProductsforDeletion);
    }
}