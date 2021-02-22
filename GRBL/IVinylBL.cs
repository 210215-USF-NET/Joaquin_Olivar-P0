using GRModels;
using System.Collections.Generic;
namespace GRBL
{
    public interface IVinylBL
    {
         List<Vinyl> GetVinyls();
        void AddVinyl(Vinyl newVinyl);
    }
}