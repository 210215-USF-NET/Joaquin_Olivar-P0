using Model = GRModels;
using Entity = GRDL.Entities;

namespace GRDL
{//Parses entities from DB to models
    public interface IMapper
    {
        Model.Record ParseRecord(Entity.Record record);
        Entity.Record ParseRecord(Model.Record record);
        Model.Customer ParseCustomer(Entity.Customer customer);
        Entity.Customer ParseCustomer(Model.Customer customer);
        Entity.Location ParseLocation(Model.LocationClass location);
        Model.LocationClass ParseLocation(Entity.Location location);
       // Model.Cart ParseCart(Entity.Cart cart);
        //Entity.Cart ParseCart(Model.Cart cart);
        //Model.CartProducts ParseCartProducts(Entity.Cartproduct cartproduct);
        //Entity.Cartproduct ParseCartProducts(Model.CartProducts cartproduct);
        //Model.Inventory ParseInventory(Entity.Inventory inventory);
        //Entity.Inventory ParseInventory(Model.Inventory inventory);
        //Model.Orders ParseOrder(Entity.Order order);
        //Entity.Order ParseOrder(Model.Orders order);
        //Model.OrderProducts ParseOrderProduct(Entity.Orderproduct orderproduct);
        //Entity.Orderproduct ParseOrderProduct(Model.OrderProducts orderproduct);


    }
}