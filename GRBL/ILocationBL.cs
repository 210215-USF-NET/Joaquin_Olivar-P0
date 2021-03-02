using GRModels;
namespace GRBL
{
    public interface ILocationBL
    {
        LocationClass GetThisLocation(int localID);
    }
}