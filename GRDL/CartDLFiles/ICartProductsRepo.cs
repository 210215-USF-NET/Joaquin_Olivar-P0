using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    public interface ICartProductsRepo
    {
        CartProducts AddToCartProducts(int RecID, int RecQuan);
        List<CartProducts> GetCartProducts();
        void PurgeCartProducts(CartProducts cartProductsforDeletion);
    }
}