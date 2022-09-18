using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.BaseEntityModel;

namespace Core.GenericRepository;

 public class BaseRepository<T> : IBaseRepository<T>
         where T : class, IBaseModel, new()
 {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        { 
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().CountAsync(predicate);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Remove(entity); });
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
                query = query.Where(predicate);
            return await query.SingleOrDefaultAsync();
        }

        public async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if(predicate !=null)
                query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Update(entity);}); 
        }
    }