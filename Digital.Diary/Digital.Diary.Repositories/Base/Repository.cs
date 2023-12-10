using Digital.Diary.Databases.Data;
using Digital.Diary.Repositories.Abstractions.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }

        public virtual bool Create(T entity)
        {
            Table.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            Table.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public virtual bool Remove(T entity)
        {
            Table.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public virtual ICollection<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return Table.ToList();
            }
            return Table.Where(predicate).ToList();
        }
    }
}