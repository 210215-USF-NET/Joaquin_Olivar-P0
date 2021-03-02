using GRModels;
using System.Collections.Generic;
namespace GRBL
{
    public interface ICartProductsBL
    {
        CartProducts AddToCartProducts(int RecID, int RecQuan);
        List<CartProducts> GetCartProducts();
    }
}