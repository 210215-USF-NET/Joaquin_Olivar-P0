using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using System.Collections.Generic;
using GRDL.Entities;

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
                Price = (float) record.Price

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
                Price = record.Price
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
                ZipCode = customer.Zip
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
                Zip = customer.ZipCode 
            };
        }
        public Model.LocationClass ParseLocation(Entity.Location location)
        {
            return new Model.LocationClass
            {
                localName = location.LocName
            };
        }
        public Entity.Location ParseLocation(Model.LocationClass location)
        {
            return new Entity.Location
            {
                LocName = location.localName
            };
        }
    }
}