using Model = GRModels;
using Entity = GRDL.Entities;
namespace GRDL
{
    public interface ICustomerMapper
    {
        Model.Customer ParseCustomer(Entity.Customer customer);
        Entity.Customer ParseCustomer(Model.Customer customer);
    }
}