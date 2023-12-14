using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Models.EntityModels.Administration.Offices;
using Digital.Diary.Repositories.Abstractions.Administration.Offices;
using Digital.Diary.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Repositories.Administration.Offices
{
    public class OfficeEmployeeRepository : Repository<OfficeEmployee>, IOfficeEmployeeRepository
    {
        public OfficeEmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override OfficeEmployee GetFirstOrDefault(Expression<Func<OfficeEmployee, bool>> predicate)
        {
            return _dbContext.Set<OfficeEmployee>().FirstOrDefault(predicate);
        }

        public override ICollection<OfficeEmployee> GetAll(Expression<Func<OfficeEmployee, bool>>? predicate = null)
        {
            var result = from t in _dbContext.Set<OfficeEmployee>()
                         join d in _dbContext.Designations on t.DesignationId equals d.Id
                         join o in _dbContext.Offices on t.OfficeId equals o.Id
                         select new OfficeEmployee
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Email = t.Email,
                             PhoneNum = t.PhoneNum,
                             ProfileImage = t.ProfileImage,
                             DesignationId = d.Id,
                             OfficeId = o.Id,
                         };
            return result.ToList();
        }
    }
}
