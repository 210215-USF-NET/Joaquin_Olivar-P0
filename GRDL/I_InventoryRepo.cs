using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    public interface I_InventoryRepo
    {
        List<Inventory> GetInventory(int localID);
        void AddToInventory(int localID, int RecID, int RecQuan);
    }
}