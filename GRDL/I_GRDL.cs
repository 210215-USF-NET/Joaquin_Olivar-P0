using GRModels;
using System.Collections.Generic;
namespace GRDL
{
    public interface I_GRDL
    {
    //Record objects methods
        List<Record> GetPhillyRecords();
        List<Record> GetNYCRecords();
        Record AddPhillyRecord(Record newRecord);
        Record AddNYCRecord(Record newRecord);
        Record SearchRecordByName(string name);
        Record SearchRecordByID(int RecID);
    //Order & order products methods
        void AddOrder(Order order);
        List<Order> GetOrdersByID(int CustomerID);
        void AddOrderProducts(OrderProducts orderProducts);
        List<OrderProducts> GetOrderProductsByID(int OrderID);
    //Customer methods
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer newCustomer);
        Customer SearchCustomerByFName(string name);
        Customer SearchCustomerByID(int CustomerID);
    //Cart & cart products methods
        Cart NewCart(int customerID);
        void AddToCartProducts(CartProducts cartProducts);
        List<CartProducts> GetCartProducts();
        void PurgeCartProducts(CartProducts cartProductsforDeletion);
    //Inventory methods
        List<Inventory> GetInventory(int localID);
        void AddToInventory(int localID, int RecID, int RecQuan);
    //Locaton methods
        LocationClass GetThisLocation(int localID);

    }
}