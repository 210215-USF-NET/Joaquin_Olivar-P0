using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    
    public interface IRecordRepo
    {
        List<Record> GetPhillyRecords();
        List<Record> GetNYCRecords();
        Record AddPhillyRecord(Record newRecord);
        Record AddNYCRecord(Record newRecord);
    }
}