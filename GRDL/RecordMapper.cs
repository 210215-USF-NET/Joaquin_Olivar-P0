using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using System.Collections.Generic;

namespace GRDL
{
    public class RecordMapper : IMapper
    {
        public Model.Record ParseRecord(Entity.Record record)
        {
            return new Model.Record
            {
                RecordName = record.RecordName,
                Artist = record.ArtistName,
                GenreType = (Model.Genre) record.Genre,
                daFormat = (Model.Format) record.RecFormat,
                daCondition = (Model.Condition) record.Condition,
                Price = (float) record.Price

            };
        }

        public Entity.Record ParseRecord(Model.Record record)
        {
            return new Entity.Record
            {
                RecordName = record.RecordName,
                ArtistName = record.Artist,
                Genre = (int) record.GenreType,
                RecFormat = (int) record.daFormat,
                Condition = (int) record.daCondition,
                Price = record.Price
            };
        }
    }
}