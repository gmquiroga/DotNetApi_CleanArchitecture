using ContactRecord.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactRecord.Application.Interfaces
{
    public interface IContactRecordService
    {
        Task<Core.Entities.ContactRecord> GetByIdAsync(int id);

        Task<Core.Entities.ContactRecord> GetByEmailAsync(string email);

        Task<IEnumerable<Core.Entities.ContactRecord>> GetAllAsync();

        Task<IEnumerable<Core.Entities.ContactRecord>> GetByStateOrCityAsync(string stateOrCity);

        Task<int> AddAsync(CreateContactRecordInput input);

        Task<int> UpdateAsync(UpdateContactRecordInput input);

        Task<int> DeleteAsync(int id);
    }
}
