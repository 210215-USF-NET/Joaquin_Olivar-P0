using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    public interface IVinylRepo
    {
         List<Vinyl> GetVinyls();
         Vinyl AddVinyl(Vinyl newVinyl);
    }
}