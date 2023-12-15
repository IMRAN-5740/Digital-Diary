using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Miscellaneous;
using Digital.Diary.Models.EntityModels.Student_Activities.Clubs;
using Digital.Diary.Repositories.Abstractions.Student_Activities.Clubs;
using Digital.Diary.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Repositories.Student_Activities.Clubs
{
    public class ClubEmployeeRepository : Repository<ClubEmployee>, IClubEmployeeRepository
    {
        public ClubEmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override ClubEmployee GetFirstOrDefault(Expression<Func<ClubEmployee, bool>> predicate)
        {
            return _dbContext.Set<ClubEmployee>().FirstOrDefault(predicate);
        }

        public override ICollection<ClubEmployee> GetAll(Expression<Func<ClubEmployee, bool>>? predicate = null)
        {
            var result = from t in _dbContext.Set<ClubEmployee>()
                         join d in _dbContext.Designations on t.DesignationId equals d.Id
                         join to in _dbContext.Clubs on t.ClubId equals to.Id
                         select new ClubEmployee
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Email = t.Email,
                             PhoneNum = t.PhoneNum,
                             ProfileImage = t.ProfileImage,
                             DesignationId = d.Id,
                             ClubId = to.Id,
                         };
            return result.ToList();
        }
    }
}