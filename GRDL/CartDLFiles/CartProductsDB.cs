using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GRModels;
using System.Collections.Generic;

namespace GRDL
{
    public class CartProductsDB : ICartProductsRepo
    {
        private Entity.GRdatabaseContext _context;
        private IMapper _mapper;
        public CartProductsDB(Entity.GRdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddToCartProducts(CartProducts cartProducts)
        {   
            cartProducts.CPID = RNG.numb.Next(1,1001);
            _context.Cartproducts.Add(_mapper.ParseCartProducts(cartProducts));
            _context.SaveChanges();
        }

        public List<CartProducts> GetCartProducts()
        {
            return _context.Cartproducts.Select(x => _mapper.ParseCartProducts(x)).AsNoTracking().ToList();
        }

        public void PurgeCartProducts(CartProducts cartProductsforDeletion)
        {
            _context.Cartproducts.Remove(_mapper.ParseCartProducts(cartProductsforDeletion));
            _context.SaveChanges();
        }
    }
}