using GRModels;
using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
namespace GRDL
{
    public class CartRepoDB : ICartRepo

    {
        private Entity.GRdatabaseContext _context;
        private IMapper _mapper;
        public CartRepoDB(Entity.GRdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Cart NewCart(int customerID)
        {
            Entity.Cart newCart = new Entity.Cart();
            newCart.IdCust = customerID;
            _context.Carts.Add(newCart);
            _context.SaveChanges();
            return _mapper.ParseCart(newCart);
        }
    }
}