using System;
using System.Collections.Generic;
using GRModels;
using System.IO;
using System.Text.Json;

namespace GRDL
{    
    public class RecordRepoFile : IRecordRepo
    {
        private string jsonString;
        private string filePath = "./GRDL/RecordFiles.json";

        public Record AddRecord(Record newRecord)
        {
            List<Record> recordsFromFile = GetRecords();
            recordsFromFile.Add(newRecord);
            jsonString = JsonSerializer.Serialize(recordsFromFile);
            File.WriteAllText(filePath, jsonString);
            return newRecord;
        }

        public List<Record> GetRecords()
        {
            try
            {
            jsonString = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                return new List<Record>();
            }
            return JsonSerializer.Deserialize<List<Record>>(jsonString);
        }
    }
}
