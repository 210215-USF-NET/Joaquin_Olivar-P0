using GRModels;
using System.Collections.Generic;

namespace GRDL
{
    public class RecordRepoSC : IRecordRepo
    {

        public List<Record> GetPhillyRecords()
        {
            return Location.PhillyRecords;
        }
        public List<Record> GetNYCRecords()
        {
            return Location.NYCRecords;
        }

        public Record AddPhillyRecord(Record newRecord)
        {
            Location.PhillyRecords.Add(newRecord);
            return newRecord;
        }
        public Record AddNYCRecord(Record newRecord)
        {
            Location.NYCRecords.Add(newRecord);
            return newRecord;
        }
    }
}