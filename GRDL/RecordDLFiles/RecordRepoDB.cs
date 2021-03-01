using System.Collections.Generic;
using Model = GRModels;
using Entity = GRDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GRDL
{
    public class RecordRepoDB : IRecordRepo
    {
        private Entity.GRdatabaseContext _context;
        private IRecordMapper _mapper;
        public RecordRepoDB(Entity.GRdatabaseContext context, IRecordMapper mapper)
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
            return _context.Records.Select(x => _mapper.ParseRecord(x)).ToList();
        }

        public List<Model.Record> GetPhillyRecords()
        {
            return _context.Records.Select(x => _mapper.ParseRecord(x)).ToList();
        }
    }
}