using GRModels;
using System.Collections.Generic;
namespace GRBL
{
    public interface ICustomerBL
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer newCustomer);
        Customer SearchCustomerByName(string name);
    }
}