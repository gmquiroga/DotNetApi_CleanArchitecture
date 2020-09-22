using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactRecord.Core.SeedWork
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

        IUnitOfWork UnitOfWork { get; }

    }
}
