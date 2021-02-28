using Model = GRModels;
using Entity = GRDL.Entities;
namespace GRDL
{//Parses entities from DB to models
    public interface IMapper
    {
        Model.Record ParseRecord(Entity.Record record);
        Entity.Record ParseRecord(Model.Record record);
    }
}