using System;
using System.Collections.Generic;
using GRDL;
using GRModels;
namespace GRBL
{
    public interface I_InventoryBL
    {
        List<Inventory> GetInventory();
    }
}