using System.Collections.Generic;
using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GRModels;

namespace GRDL
{
    public class CustomerRepoDB : ICustomerRepo
    {
        private Entity.GRdatabaseContext _context;
        private IMapper _mapper;
        public CustomerRepoDB(Entity.GRdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Customer AddCustomer(Model.Customer newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return newCustomer;
        }

        public List<Model.Customer> GetCustomers()
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList();
        }

        public Customer SearchCustomerByFName(string name)
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.FirstName == name);
        }
        public Customer SearchCustomerByID(int CustomerID)
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.CustomerID == CustomerID);
        }
    }
}