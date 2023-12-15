using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Models.EntityModels.Miscellaneous;
using Digital.Diary.Repositories.Abstractions.Miscellaneous;
using Digital.Diary.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Repositories.Miscellaneous
{
    public class BankEmployeeRepository : Repository<BankEmployee>, IBankEmployeeRepository
    {
        public BankEmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override BankEmployee GetFirstOrDefault(Expression<Func<BankEmployee, bool>> predicate)
        {
            return _dbContext.Set<BankEmployee>().FirstOrDefault(predicate);
        }

        public override ICollection<BankEmployee> GetAll(Expression<Func<BankEmployee, bool>>? predicate = null)
        {
            var result = from t in _dbContext.Set<BankEmployee>()
                         join d in _dbContext.Designations on t.DesignationId equals d.Id
                         join to in _dbContext.Banks on t.BankId equals to.Id
                         select new BankEmployee
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Email = t.Email,
                             PhoneNum = t.PhoneNum,
                             ProfileImage = t.ProfileImage,
                             DesignationId = d.Id,
                             BankId = to.Id,
                         };
            return result.ToList();
        }
    }
}