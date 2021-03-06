using GRModels;
using System.Collections.Generic;
using GRDL;
namespace GRBL
{
    public class GRBL_Class : I_GRBL
    {
        private I_GRDL _repo;
        public GRBL_Class(I_GRDL repo)
        {
            _repo = repo;
        }
        //Record object methods
            public void AddPhillyRecord(Record newRecord)
            {
                _repo.AddPhillyRecord(newRecord);
            }
            public void AddNYCRecord(Record newRecord)
            {
                _repo.AddNYCRecord(newRecord);
            }
            public List<Record> GetPhillyRecords()
            {
                return _repo.GetPhillyRecords();
            }
            public List<Record> GetNYCRecords()
            {
                return _repo.GetNYCRecords();
            }
            public Record SearchRecordByName(string name)
            {
                return _repo.SearchRecordByName(name);
            }
            public Record SearchRecordByID(int RecID)
            {
                return _repo.SearchRecordByID(RecID);
            }
        //Order & Order Products methods
            public void AddOrder(Order order)
            {
                _repo.AddOrder(order);
            }
            public List<Order> GetOrdersByID(int CustomerID)
            {
                return _repo.GetOrdersByID(CustomerID);
            }
            public void addOrderProducts(OrderProducts newOrderProducts)
            {
                _repo.AddOrderProducts(newOrderProducts);
            }
            public List<OrderProducts> GetOrderProductsByID(int OrderID)
            {
                return _repo.GetOrderProductsByID(OrderID);
            }
        //Customer methods
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
            public Customer SearchCustomerByID(int CustomerID)
            {
                return _repo.SearchCustomerByID(CustomerID);
            }
         //Cart & cart product methods
            public Cart newCart(int customerID)
            {
                return _repo.NewCart(customerID);
            }
            public void AddToCartProducts(CartProducts cartProducts)
            {
                _repo.AddToCartProducts(cartProducts);
            }
            public List<CartProducts> GetCartProducts()
            {
                return _repo.GetCartProducts();
            }
            public void PurgeCartProducts(CartProducts cartProductsforDeletion)
            {
                _repo.PurgeCartProducts(cartProductsforDeletion);
            }
        //Inventory methods
            public List<Inventory> GetInventory(int localID)
            {
                return _repo.GetInventory(localID);
            }
            public void AddToInventory(int localID, int RecID, int RecQuan)
            {
                _repo.AddToInventory(localID, RecID, RecQuan);
            }
        //Location methods
        public LocationClass GetThisLocation(int localID)
        {
            return _repo.GetThisLocation(localID);
        }
    }
}