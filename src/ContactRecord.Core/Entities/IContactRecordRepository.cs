using ContactRecord.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactRecord.Core.Entities
{
    public interface IContactRecordRepository : IRepository<ContactRecord>
    {
        Task<ContactRecord> GetByEmailAsync(string email);

        Task<IEnumerable<Core.Entities.ContactRecord>> GetByStateOrCityAsync(string stateOrCity);
    }
}
