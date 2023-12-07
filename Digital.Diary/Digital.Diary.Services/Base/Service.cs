using Digital.Diary.Models;
using Digital.Diary.Repositories.Abstractions.Base;
using Digital.Diary.Services.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Services.Base
{
    public abstract class Service<T> : IService<T> where T : class
    {
        IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual Result Create(T entity)
        {

            var result = new Result();
            bool isSuccess = _repository.Create(entity);
            if (isSuccess)
            {
                result.IsSucced = true;
                return result;
            }
            result.ErrorMessages.Add("Could  Not Add Entity");
            return result;
        }
        public virtual Result Update(T entity)
        {
            var result = new Result();
            bool isSuccess = _repository.Update(entity);
            if (isSuccess)
            {
                result.IsSucced = true;
                return result;
            }
            result.ErrorMessages.Add("Could  Not Update Entity");
            return result;
        }
        public virtual Result Remove(T entity)
        {
            var result = new Result();
            bool isSuccess = _repository.Remove(entity);
            if (isSuccess)
            {
                result.IsSucced = true;
                return result;
            }
            result.ErrorMessages.Add("Could  Not Remove Entity");
            return result;
        }
        
        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetFirstOrDefault(predicate);
        }
        public virtual ICollection<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            return _repository.GetAll(predicate);
        }
    }
}

