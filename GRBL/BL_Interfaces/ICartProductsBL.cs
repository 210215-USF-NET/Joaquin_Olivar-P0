using GRModels;
namespace GRBL
{
    public interface ICartProductsBL
    {
        CartProducts AddToCartProducts(int RecID, int RecQuan);
    }
}