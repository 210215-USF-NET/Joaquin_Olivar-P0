using System;
using System.Collections.Generic;
using GRModels;
using System.IO;
using System.Text.Json;

namespace GRDL
{    public class RecordRepoFile : IRecordRepo
    {
        private string jsonString;
        private string filePath = "./GRDL/RecordFiles.json";

        public Record AddRecord(Record newRecord)
        {
            jsonString = JsonSerializer.Serialize(newRecord);
            File.WriteAllText(filePath, jsonString);
            return newRecord;
        }

        public List<Record> GetRecords()
        {
            jsonString = File.ReadAllText(filePath);
            Record fileRecord = JsonSerializer.Deserialize<Record>(jsonString);
            return new List<Record> { fileRecord };
        }
    }
}
