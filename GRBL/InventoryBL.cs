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
        public List<Inventory> GetInventory(int localID)
        {
            return _repo.GetInventory(localID);
        }
        public void AddToInventory(int localID, int RecID, int RecQuan)
        {
            _repo.AddToInventory(localID, RecID, RecQuan);
        }
    }
}