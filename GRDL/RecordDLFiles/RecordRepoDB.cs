using System.Collections.Generic;
using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GRModels;

namespace GRDL
{
    public class RecordRepoDB : IRecordRepo
    {
        private Entity.GRdatabaseContext _context;
        private IMapper _mapper;
        public RecordRepoDB(Entity.GRdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Record AddNYCRecord(Model.Record newRecord)
        {
            _context.Records.Add(_mapper.ParseRecord(newRecord));
            _context.SaveChanges();
            return newRecord;
        }

        public Model.Record AddPhillyRecord(Model.Record newRecord)
        {
            _context.Records.Add(_mapper.ParseRecord(newRecord));
            _context.SaveChanges();
            return newRecord;
        }

        public List<Model.Record> GetNYCRecords()
        {
            //_context.Locations.Select(x => _mapper.ParseLocation(x)).ToList().Where(x => x.localName == location);
            return _context.Records.Select(x => _mapper.ParseRecord(x)).ToList();
        }

        public List<Model.Record> GetPhillyRecords()
        {
            
            return _context.Records.Select(x => _mapper.ParseRecord(x)).ToList();
        }

        public Record SearchRecordByName(string name)
        {
            return _context.Records.Select(x => _mapper.ParseRecord(x)).ToList().FirstOrDefault(x => x.RecordName == name);
        }
    }
}