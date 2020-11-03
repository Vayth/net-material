using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Domain.SeedWork
{
    public interface IRepository<T, TKey> where T : Entity<TKey>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(TKey id);
        Task<T> GetAsync(TKey id);
        T Add(T entity);
        Task<T> AddAsync(T entity);
    }
}
