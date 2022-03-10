using System.Linq.Expressions;

namespace MovieApp.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string[] includes = null);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> match, string [] includes= null);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
