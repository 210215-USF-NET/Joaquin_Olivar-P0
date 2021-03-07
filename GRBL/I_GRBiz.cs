using GRModels;
using System.Collections.Generic;
namespace GRBL
{
    public interface I_GRBiz
    {
    //Record object methods
        List<Record> GetPhillyRecords();
        List<Record> GetNYCRecords();
        void AddPhillyRecord(Record newRecord);
        void AddNYCRecord(Record newRecord);
        Record SearchRecordByName(string name);
        Record SearchRecordByID (int RecID);
    //Order & Order Products methods
        void AddOrder(Order order);
        List<Order> GetOrdersByID(int CustomerID);
        void addOrderProducts(OrderProducts newOrderProducts);
        List<OrderProducts> GetOrderProductsByID(int OrderID);
    //Customer methods
        List<Customer> GetCustomers();
        void AddCustomer(Customer newCustomer);
        Customer SearchCustomerByFName(string name);
        Customer SearchCustomerByID(int CustomerID);
    //Cart & cart product methods
        Cart newCart(int customerID);  
        void AddToCartProducts(CartProducts cartProducts);
        List<CartProducts> GetCartProducts();
        void PurgeCartProducts(CartProducts cartProductsforDeletion);
    //Inventory methods
        List<Inventory> GetInventory(int localID);
        void AddToInventory(int localID, int RecID, int RecQuan);
    //Location methods
        LocationClass GetThisLocation(int localID);
    }
}