using Digital.Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Services.Abstractions.Base
{
       public interface IService<T> where T : class
        {
            ICollection<T> GetAll(Expression<Func<T, bool>>? predicate = null);
            T GetFirstOrDefault(Expression<Func<T, bool>> predicate);

            Result Create(T entity);
            Result Update(T entity);
            Result Remove(T entity);
        }
    
}
