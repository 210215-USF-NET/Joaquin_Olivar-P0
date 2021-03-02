using System.Collections.Generic;
using GRModels;
using GRDL;

namespace GRBL
{
    public class InventoryBL : I_InventoryBL
    {
        private I_InventoryRepo _repo;
        public InventoryBL(I_InventoryRepo repo)
        {
            _repo = repo;
        }
        public List<Inventory> GetInventory()
        {
            return _repo.GetInventory();
        }
    }
}