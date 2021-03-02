using GRDL;
using GRModels;

namespace GRBL
{
    public class LocationBL : ILocationBL
    {
        private ILocationRepoDB _repo;
        public LocationBL(ILocationRepoDB repo)
        {
            _repo = repo;
        }         
        public LocationClass GetThisLocation(int localID)
        {
            return _repo.GetThisLocation(localID);
        }
    }
}