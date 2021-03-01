using System;
using System.Collections.Generic;
using GRDL;
using GRModels;

namespace GRBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepo _repo;
        public CustomerBL(ICustomerRepo repo)
        {
            _repo = repo;
        }
        public void AddCustomer(Customer newCustomer)
        {
            _repo.AddCustomer(newCustomer);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public Customer SearchCustomerByFName(string name)
        {
            return _repo.SearchCustomerByFName(name);
        }
    }
}