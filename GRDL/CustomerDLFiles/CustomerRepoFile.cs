using System;
using System.Collections.Generic;
using GRModels;
using System.IO;
using System.Text.Json;

namespace GRDL
{
    public class CustomerRepoFile : ICustomerRepo
    {
        private string jsonString;
        private string filePath = "../GRDL/CustomerDLFiles/CustomerFiles.json";

        public Customer AddCustomer(Customer newCustomer)
        {
            List<Customer> customersFromFile = GetCustomers();
            customersFromFile.Add(newCustomer);
            jsonString = JsonSerializer.Serialize(customersFromFile);
            File.WriteAllText(filePath, jsonString);
            return newCustomer;
        }

        public List<Customer> GetCustomers()
        {
            try
            {
            jsonString = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }
    }
}