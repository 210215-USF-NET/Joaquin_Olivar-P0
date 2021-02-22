using GRModels;
using System.Collections.Generic;
namespace GRBL
{
    public interface IRecordBL
    {
        List<Record> GetRecords();
        void AddRecord(Record newRecord);
    }
}