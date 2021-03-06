using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GRModels;
namespace GRDL
{
    public class GRDL_Class : I_GRDL
    {
        private Entity.GRdatabaseContext _context;
        private IMapper _mapper;
        public GRDL_Class(Entity.GRdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        List<Model.Record> I_GRDL.GetPhillyRecords()
        {
            return _context.Records.Select(x => _mapper.ParseRecord(x)).ToList();
        }
        List<Model.Record> I_GRDL.GetNYCRecords()
        {
            return _context.Records.Select(x => _mapper.ParseRecord(x)).ToList();
        }
        Model.Record I_GRDL.AddPhillyRecord(Model.Record newRecord)
        {
            _context.Records.Add(_mapper.ParseRecord(newRecord));
            _context.SaveChanges();
            return newRecord;
        }
        Record I_GRDL.AddNYCRecord(Model.Record newRecord)
        {
            _context.Records.Add(_mapper.ParseRecord(newRecord));
            _context.SaveChanges();
            return newRecord;
        }
        Model.Record I_GRDL.SearchRecordByName(string name)
        {
            return _context.Records.Select(x => _mapper.ParseRecord(x)).ToList().FirstOrDefault(x => x.RecordName == name);
        }
        Model.Record I_GRDL.SearchRecordByID(int RecID)
        {
            return _context.Records.Select(x => _mapper.ParseRecord(x)).ToList().FirstOrDefault(x => x.RecID == RecID);
        }
    //Order & order products methods
        void I_GRDL.AddOrder(Model.Order order)
        {
            order.OrdID = RNG.numb.Next(1,1001);
            _context.Orders.Add(_mapper.ParseOrder(order));
            _context.SaveChanges();
        }
        List<Model.Order> I_GRDL.GetOrdersByID(int CustomerID)
        {
            return _context.Orders.AsNoTracking().Where(x => x.IdCust == CustomerID).Select(x => _mapper.ParseOrder(x)).ToList();
        }
        void I_GRDL.AddOrderProducts(Model.OrderProducts orderProducts)
        {
            orderProducts.OrdProdId = RNG.numb.Next(1,1001);
            _context.Orderproducts.Add(_mapper.ParseOrderProduct(orderProducts));
            _context.SaveChanges();
        }
        
        List<Model.OrderProducts> I_GRDL.GetOrderProductsByID(int OrderID)
        {
            return _context.Orderproducts.AsNoTracking().Where(x => x.Idorder == OrderID).Select(x => _mapper.ParseOrderProduct(x)).ToList();
        }
    //Customer methods
        List<Model.Customer> I_GRDL.GetCustomers()
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList();
        }
        Model.Customer I_GRDL.AddCustomer(Model.Customer newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return newCustomer;
        }
        Model.Customer I_GRDL.SearchCustomerByFName(string name)
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.FirstName == name);
        }
        Model.Customer I_GRDL.SearchCustomerByID(int CustomerID)
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.CustomerID == CustomerID);
        }
    //Cart & cart products methods
        Model.Cart I_GRDL.NewCart(int customerID)
        {
            Entity.Cart newCart = new Entity.Cart();
            newCart.Id = RNG.numb.Next(1,1001);
            newCart.IdCust = customerID;
            _context.Carts.Add(newCart);
            _context.SaveChanges();
            return _mapper.ParseCart(newCart);
        }
        void I_GRDL.AddToCartProducts(Model.CartProducts cartProducts)
        {
            cartProducts.CPID = RNG.numb.Next(1,1001);
            _context.Cartproducts.Add(_mapper.ParseCartProducts(cartProducts));
            _context.SaveChanges();
        }
        List<Model.CartProducts> I_GRDL.GetCartProducts()
        {
            return _context.Cartproducts.Select(x => _mapper.ParseCartProducts(x)).AsNoTracking().ToList();
        }
        void I_GRDL.PurgeCartProducts(Model.CartProducts cartProductsforDeletion)
        {
            _context.ChangeTracker.Clear();
            _context.Cartproducts.RemoveRange(_mapper.ParseCartProducts(cartProductsforDeletion));
            _context.SaveChanges();
        }
    //Inventory methods
        List<Model.Inventory> I_GRDL.GetInventory(int localID)
        {
            return _context.Inventories.AsNoTracking().Where(x => x.IdLoc == localID).Select(x => _mapper.ParseInventory(x)).ToList();
        }
        void I_GRDL.AddToInventory(int localID, int RecID, int RecQuan)
        {
            Entity.Inventory newItem = new Entity.Inventory();
            newItem.IdLoc = localID;
            newItem.IdRec = RecID;
            newItem.NumbRec = RecQuan;
            newItem.IdInv = RNG.numb.Next(20,100);
            _context.Inventories.Add(newItem);
            _context.SaveChanges();
        }
    //Locaton methods
        LocationClass I_GRDL.GetThisLocation(int localID)
        {
            Entities.Location location = _context.Locations.Find(localID);
            return _mapper.ParseLocation(location);
        }
    }
}