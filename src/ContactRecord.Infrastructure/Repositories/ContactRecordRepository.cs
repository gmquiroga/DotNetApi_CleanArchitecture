using ContactRecord.Core.Entities;
using ContactRecord.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContactRecord.Infrastructure.Repositories
{
    public class ContactRecordRepository : IContactRecordRepository
    {
        private readonly ContactRecordContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ContactRecordRepository(ContactRecordContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Core.Entities.ContactRecord contactRecord)
        {
            await _context.ContactRecord.AddAsync(contactRecord);
        }

        public void Delete(Core.Entities.ContactRecord contactRecord)
        {
            _context.ContactRecord.Remove(contactRecord);
        }

        public async Task<IEnumerable<Core.Entities.ContactRecord>> GetAllAsync()
        {
            return await _context.ContactRecord.ToListAsync<Core.Entities.ContactRecord>();
        }

        public async Task<Core.Entities.ContactRecord> GetByIdAsync(int id)
        {
            return await _context.ContactRecord.FindAsync(id);
        }

        public void Update(Core.Entities.ContactRecord contactRecord)
        {
            _context.ContactRecord.Update(contactRecord);
        }
        
        public async Task<IEnumerable<Core.Entities.ContactRecord>> GetByStateOrCityAsync(string stateOrCity)
        {
            return await _context.ContactRecord.Where(c => c.Address.City == stateOrCity || c.Address.State == stateOrCity).ToListAsync();
        }

        public async Task<Core.Entities.ContactRecord> GetByEmailAsync(string email)
        {
            return await _context.ContactRecord.Where(c => c.Email == email).FirstOrDefaultAsync();
        }
    }
}
