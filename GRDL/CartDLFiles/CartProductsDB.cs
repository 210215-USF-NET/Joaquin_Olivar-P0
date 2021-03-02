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
        public Model.CartProducts AddToCartProducts(int RecID, int RecQuan)
        {
            Entity.Cartproduct newCartproduct = new Entity.Cartproduct();
            newCartproduct.IdProd = RecID;
            newCartproduct.ProductQuant = RecQuan;
            _context.Cartproducts.Add(newCartproduct);
            _context.SaveChanges();
            return _mapper.ParseCartProducts(newCartproduct);
        }

        public List<CartProducts> GetCartProducts()
        {
            return _context.Cartproducts.Select(x => _mapper.ParseCartProducts(x)).ToList();
        }

        public void PurgeCartProducts(CartProducts cartProductsforDeletion)
        {
            _context.Cartproducts.Remove(_mapper.ParseCartProducts(cartProductsforDeletion));
            _context.SaveChanges();
        }
    }
}