using System.Collections.Generic;
using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GRModels;
namespace GRDL
{
    public class InventoryRepoDB : I_InventoryRepo
    {
        private Entity.GRdatabaseContext _context;
        private IMapper _mapper;
        public InventoryRepoDB(Entity.GRdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Inventory> GetInventory(int localID)
        {
            return _context.Inventories.AsNoTracking().Where(x => x.IdLoc == localID).Select(x => _mapper.ParseInventory(x)).ToList();
        }
    }
}