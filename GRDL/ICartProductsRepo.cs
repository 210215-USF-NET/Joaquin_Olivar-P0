using GRModels;
namespace GRDL
{
    public interface ICartProductsRepo
    {
        CartProducts AddToCartProducts(int RecID, int RecQuan);
    }
}