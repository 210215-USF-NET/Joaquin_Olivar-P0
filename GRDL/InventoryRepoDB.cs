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

        public void AddToInventory(int localID, int RecID, int RecQuan)
        {
            Entity.Inventory newItem = new Entity.Inventory();
            newItem.IdLoc = localID;
            newItem.IdRec = RecID;
            newItem.NumbRec = RecQuan;
            newItem.IdInv = RNG.numb.Next(20,100);
            _context.Inventories.Add(newItem);
            _context.SaveChanges();
        }

        public List<Model.Inventory> GetInventory(int localID)
        {
            return _context.Inventories.AsNoTracking().Where(x => x.IdLoc == localID).Select(x => _mapper.ParseInventory(x)).ToList();
        }
    }
}