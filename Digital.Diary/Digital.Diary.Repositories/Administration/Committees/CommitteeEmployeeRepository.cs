using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Repositories.Abstractions.Administration.Committees;
using Digital.Diary.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Repositories.Administration.Committees
{
    public class CommitteeEmployeeRepository : Repository<CommitteeEmployee>, ICommitteeEmployeeRepository
    {
        public CommitteeEmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override CommitteeEmployee GetFirstOrDefault(Expression<Func<CommitteeEmployee, bool>> predicate)
        {
            return _dbContext.Set<CommitteeEmployee>().FirstOrDefault(predicate);
        }

        public override ICollection<CommitteeEmployee> GetAll(Expression<Func<CommitteeEmployee, bool>>? predicate = null)
        {
            var result = from t in _dbContext.Set<CommitteeEmployee>()
                         join d in _dbContext.Designations on t.DesignationId equals d.Id
                         join ce in _dbContext.Committees on t.CommitteeId equals ce.Id
                         select new CommitteeEmployee
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Email = t.Email,
                             PhoneNum = t.PhoneNum,
                             ProfileImage = t.ProfileImage,
                             DesignationId = d.Id,
                             CommitteeId = ce.Id,
                         };
            return result.ToList();
        }
    }
}
