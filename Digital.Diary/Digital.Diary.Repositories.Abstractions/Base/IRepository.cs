using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Abstractions.Base
{
    public interface IRepository<T> where T : class
    {
        bool Create(T entity);

        bool Update(T entity);

        bool Remove(T entity);

        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);

        ICollection<T> GetAll(Expression<Func<T, bool>>? predicate = null);
    }
}