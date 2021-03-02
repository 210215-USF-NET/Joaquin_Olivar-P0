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
        public Model.Cart NewCart(Model.Cart newCart)
        {
            _context.Carts.Add(_mapper.ParseCart(newCart));
            _context.SaveChanges();
            return newCart;
        }
    }
}