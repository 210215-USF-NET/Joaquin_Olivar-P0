using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GRModels;

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
    }
}