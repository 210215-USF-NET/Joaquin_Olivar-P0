using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using System.Collections.Generic;

namespace GRDL
{
    public class CustomerMapper : ICustomerMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer
            {
                FirstName = customer.FName,
                LastName = customer.LName,
                Email = customer.EMail,
                Address = customer.Address,
                ZipCode = customer.Zip
            };
        }

        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            return new Entity.Customer
            {
                FName = customer.FirstName,
                LName = customer.LastName,
                EMail = customer.LastName,
                Address = customer.Address,
                Zip = customer.ZipCode 
            };
        }
    }
}