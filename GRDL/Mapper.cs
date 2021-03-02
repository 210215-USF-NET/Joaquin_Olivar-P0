using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using System.Collections.Generic;
using GRDL.Entities;
using GRModels;

namespace GRDL
{
    public class Mapper : IMapper
    {
        public Model.Record ParseRecord(Entity.Record record)
        {
            return new Model.Record
            {
                RecordName = record.RecordName,
                Artist = record.ArtistName,
                GenreType = (Model.Genre) record.Genre,
                daFormat = (Model.Format) record.RecFormat,
                daCondition = (Model.Condition) record.Condition,
                Price = (float) record.Price,
                RecID = record.Id

            };
        }

        public Entity.Record ParseRecord(Model.Record record)
        {
            return new Entity.Record
            {
                RecordName = record.RecordName,
                ArtistName = record.Artist,
                Genre = (int) record.GenreType,
                RecFormat = (int) record.daFormat,
                Condition = (int) record.daCondition,
                Price = record.Price,
                Id = record.RecID
            };
        }
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer
            {
                FirstName = customer.FName,
                LastName = customer.LName,
                Email = customer.EMail,
                Address = customer.Address,
                ZipCode = customer.Zip,
                CustomerID = customer.Id
            };
        }

        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            return new Entity.Customer
            {
                FName = customer.FirstName,
                LName = customer.LastName,
                EMail = customer.LastName,
                Address = customer.Address,
                Zip = customer.ZipCode,
                Id = customer.CustomerID
            };
        }
        public Model.LocationClass ParseLocation(Entity.Location location)
        {
            return new Model.LocationClass
            {
                localName = location.LocName,
                localID = location.Id
            };
        }
        public Entity.Location ParseLocation(Model.LocationClass location)
        {
            return new Entity.Location
            {
                LocName = location.localName,
                Id = location.localID
            };
        }

        public Model.Cart ParseCart(Entity.Cart cart)
        {
            return new Model.Cart
            {
                CartID = cart.Id,
                CustomerID = cart.IdCust
            };
        }

        public Entity.Cart ParseCart(Model.Cart cart)
        {
            return new Entity.Cart
            {
                Id = cart.CartID,
                IdCust = cart.CustomerID
            };
        }

        public Model.CartProducts ParseCartProducts(Entity.Cartproduct cartproduct)
        {
            return new Model.CartProducts
            {
                CPID = cartproduct.Id,
                RecID = cartproduct.IdProd,
                CartID = cartproduct.IdCart,
                RecQuan = cartproduct.ProductQuant
            };
        }

        public Entity.Cartproduct ParseCartProducts(Model.CartProducts cartproduct)
        {
            return new Entity.Cartproduct
            {
                Id = cartproduct.CPID,
                IdProd = cartproduct.RecID,
                IdCart = cartproduct.CartID,
                ProductQuant = cartproduct.RecQuan
            };
        }

        public Model.Inventory ParseInventory(Entity.Inventory inventory)
        {

            return new Model.Inventory
            {
                InvID = inventory.IdInv,
                RecID = inventory.IdRec,
                LocID = inventory.IdLoc,
                RecQuan = inventory.NumbRec
            };
        }

        public Entity.Inventory ParseInventory(Model.Inventory inventory)
        {
            return new Entity.Inventory
            {
                IdInv = inventory.InvID,
                IdRec = inventory.RecID,
                IdLoc = inventory.LocID,
                NumbRec = inventory.RecQuan
            };
        }

        public Model.Order ParseOrder(Entity.Order order)
        {
            return new Model.Order
            {
                OrdID = order.Id,
                localID = order.Location,
                CartID = order.IdCart,
                OrDate = order.ODate,

            };
        }

        public Entity.Order ParseOrder(Model.Order order)
        {
            return new Entity.Order
            {
                Id = order.OrdID,
                Location = order.localID,
                IdCart = order.CartID,
                ODate = order.OrDate
            };
        }

        public OrderProducts ParseOrderProduct(Orderproduct orderproduct)
        {
            return new Model.OrderProducts
            {
                OrdProdId = orderproduct.Id,
                RecID = orderproduct.Idproducts,
                OrdID = orderproduct.Idorder,
                RecQuan = orderproduct.Productnumb
                
            };
        }

        public Orderproduct ParseOrderProduct(OrderProducts orderproduct)
        {
            return new Entity.Orderproduct
            {
                Id = orderproduct.OrdProdId,
                Idproducts = orderproduct.RecID,
                Idorder = orderproduct.OrdID,
                Productnumb = orderproduct.RecQuan
            };
        }
    }
}