using GRModels;
using System.Collections.Generic;

namespace GRDL
{
    public class CustomerRepoSC : ICustomerRepo
    {
        public List<Customer> GetCustomers()
        {
            return Location.AllCustomers;
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            Location.AllCustomers.Add(newCustomer);
            return newCustomer;
        }
    }
}