using LeaveRequest.Domain.SeedWork;
using LeaveRequest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Infrastructure.Repositories
{
    public class BaseRepository<T, TKey> : IRepository<T, TKey> where T : Entity<TKey>
    {
        private readonly LeaveRequestDbContext _context;

        public BaseRepository(LeaveRequestDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public T Get(TKey id)
        {
            return _context.Set<T>().Find(id);
        }

        public Task<T> GetAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
