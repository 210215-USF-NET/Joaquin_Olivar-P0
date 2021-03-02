using GRModels;
namespace GRDL
{
    public interface ILocationRepoDB
    {
        LocationClass GetThisLocation(int localID);
    }
}