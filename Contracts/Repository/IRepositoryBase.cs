using System.Linq.Expressions;

namespace Contracts.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        int Count();
        void Create(T entity);
        void Delete(List<T> entities);
        void Delete(T entity);
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    }
}
