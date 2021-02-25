using GRModels;
using System.Collections.Generic;

namespace GRDL
{
    public class RecordRepoSC : IRecordRepo
    {
        public List<Record> GetRecords()
        {
            return Storage.AllRecords;
        }

        public Record AddRecord(Record newRecord)
        {
            Storage.AllRecords.Add(newRecord);
            return newRecord;
        }
    }
}