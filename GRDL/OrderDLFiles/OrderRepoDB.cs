using Model = GRModels;
using Entity = GRDL.Entities;

namespace GRDL
{
    public class OrderRepoDB : IOrderRepo
    {
        private Entity.GRdatabaseContext _context;
        private IMapper _mapper;
        public OrderRepoDB(Entity.GRdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddOrder(Model.Order order)
        {
            order.OrdID = RNG.numb.Next(1,1001);
            _context.Orders.Add(_mapper.ParseOrder(order));
            _context.SaveChanges();
        }
    }
}