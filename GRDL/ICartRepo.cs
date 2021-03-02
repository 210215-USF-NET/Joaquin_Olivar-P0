using GRModels;
namespace GRDL
{
    public interface ICartRepo
    {
        Cart NewCart(int customerID);
    }
}