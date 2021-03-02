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
        private string filePathPhilly = "../GRDL/RecordDLFiles/PhillyRecordFiles.json";
        private string filePathNYC = "../GRDL/RecordDLFiles/NYRecordFiles.json";

        public Record AddPhillyRecord(Record newRecord)
        {
            List<Record> recordsFromFile = GetPhillyRecords();
            recordsFromFile.Add(newRecord);
            jsonString = JsonSerializer.Serialize(recordsFromFile);
            File.WriteAllText(filePathPhilly, jsonString);
            return newRecord;
        }
        public Record AddNYCRecord(Record newRecord)
        {
            List<Record> recordsFromFile = GetNYCRecords();
            recordsFromFile.Add(newRecord);
            jsonString = JsonSerializer.Serialize(recordsFromFile);
            File.WriteAllText(filePathNYC, jsonString);
            return newRecord;
        }

        public List<Record> GetPhillyRecords()
        {
            try
            {
            jsonString = File.ReadAllText(filePathPhilly);
            }
            catch (Exception)
            {
                return new List<Record>();
            }
            return JsonSerializer.Deserialize<List<Record>>(jsonString);
        }
        public List<Record> GetNYCRecords()
        {
            try
            {
            jsonString = File.ReadAllText(filePathNYC);
            }
            catch (Exception)
            {
                return new List<Record>();
            }
            return JsonSerializer.Deserialize<List<Record>>(jsonString);
        }

        public Record SearchRecordByName(string name)
        {
            throw new NotImplementedException();
        }

        public Record SearchRecordByID(int RecID)
        {
            throw new NotImplementedException();
        }
    }
}
