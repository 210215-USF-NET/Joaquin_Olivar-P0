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
        public void AddRecord(Record newRecord)
        {
            _repo.AddRecord(newRecord);
        }

        public List<Record> GetRecords()
        {
            return _repo.GetRecords();
        } 
    } 
}
