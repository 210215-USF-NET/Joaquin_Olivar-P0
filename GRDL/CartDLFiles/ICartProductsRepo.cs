using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    public interface ICartProductsRepo
    {
        void AddToCartProducts(CartProducts cartProducts);
        List<CartProducts> GetCartProducts();
        void PurgeCartProducts(CartProducts cartProductsforDeletion);
    }
}