using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    public interface IRecordRepo
    {
        List<Record> GetRecords();
        Record AddRecord(Record newRecord);
    }
}