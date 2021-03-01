using System;
using System.Collections.Generic;
using GRDL;
using GRModels;

namespace GRBL
{
    public class RecordBL : IRecordBL
    {   
        private IRecordRepo _repo;
        public RecordBL(IRecordRepo repo)
        {
            _repo = repo;
        }
        public void AddPhillyRecord(Record newRecord)
        {
            _repo.AddPhillyRecord(newRecord);
        }
        public void AddNYCRecord(Record newRecord)
        {
            _repo.AddNYCRecord(newRecord);
        }
        public List<Record> GetPhillyRecords()
        {
            return _repo.GetPhillyRecords();
        }
        public List<Record> GetNYCRecords()
        {
            return _repo.GetNYCRecords();
        }

        public Record SearchRecordByName(string name)
        {
            return _repo.SearchRecordByName(name);
        }
    } 
}
