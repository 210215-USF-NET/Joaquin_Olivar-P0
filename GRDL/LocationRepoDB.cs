using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
namespace GRDL
{
    public class LocationRepoDB : ILocationRepoDB
    {
        private Entity.GRdatabaseContext _context;
        private IMapper _mapper;
        public LocationRepoDB(Entity.GRdatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public Model.LocationClass GetThisLocation(int localID)
        {
            Entities.Location location = _context.Locations.Find(localID);
            return _mapper.ParseLocation(location);

        }
    }
}