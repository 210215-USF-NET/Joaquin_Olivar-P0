using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GRModels;

namespace GRDL
{
    public class OrderProductsRepoDB : IOrderProductsRepo
    {
        private Entity.GRdatabaseContext _context;
        private IMapper _mapper;
        public OrderProductsRepoDB(Entity.GRdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddOrderProducts(Model.OrderProducts orderProducts)
        {   orderProducts.OrdProdId = RNG.numb.Next(1,1001);
            _context.Orderproducts.Add(_mapper.ParseOrderProduct(orderProducts));
            _context.SaveChanges();
        }

        public List<Model.OrderProducts> GetOrderProductsByID(int OrderID)
        {
            return _context.Orderproducts.AsNoTracking().Where(x => x.Idorder == OrderID).Select(x => _mapper.ParseOrderProduct(x)).ToList();
        }
    }
}