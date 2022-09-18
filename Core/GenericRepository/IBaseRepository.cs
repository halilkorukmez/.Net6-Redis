using System.Linq.Expressions;
using Core.BaseEntityModel;
namespace Core.GenericRepository;

public interface IBaseRepository<T> where T : class, IBaseModel , new()
{
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<T,bool>> predicate);
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IList<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
}