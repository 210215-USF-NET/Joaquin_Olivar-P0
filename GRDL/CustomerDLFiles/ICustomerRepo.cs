using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    public interface ICustomerRepo
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer newCustomer);
        Customer SearchCustomerByFName(string name);
        Customer SearchCustomerByID(int CustomerID);
    }
}