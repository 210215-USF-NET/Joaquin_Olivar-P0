using GRModels;
using System.Collections.Generic;

namespace GRDL.CustomerDLFiles
{
    public class CustomerRepoSC : ICustomerRepo
    {
        public List<Customer> GetCustomers()
        {
            return Storage.AllCustomers;
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            Storage.AllCustomers.Add(newCustomer);
            return newCustomer;
        }
    }
}