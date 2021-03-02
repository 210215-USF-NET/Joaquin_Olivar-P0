using GRModels;
using System.Collections.Generic;
namespace GRBL
{
    public interface IRecordBL
    {
        List<Record> GetPhillyRecords();
        List<Record> GetNYCRecords();
        void AddPhillyRecord(Record newRecord);
        void AddNYCRecord(Record newRecord);

        Record SearchRecordByName(string name);
        Record SearchRecordByID (int RecID);
    }
}