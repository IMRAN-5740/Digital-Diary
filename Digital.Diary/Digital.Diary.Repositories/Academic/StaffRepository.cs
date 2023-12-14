using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Repositories.Abstractions.Academic;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Academic
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Staff GetFirstOrDefault(Expression<Func<Staff, bool>> predicate)
        {
            return _dbContext.Set<Staff>().FirstOrDefault(predicate);
        }

        public override ICollection<Staff> GetAll(Expression<Func<Staff, bool>>? predicate = null)
        {
            var result = from d in _dbContext.Set<Staff>()
                         join f in _dbContext.Departments on d.DepartmentId equals f.Id
                         select new Staff
                         {
                             Id = d.Id,
                             Name = d.Name,
                             Email = d.Email,
                             PhoneNum = d.PhoneNum,
                             ProfileImage = d.ProfileImage,
                             DesignationId = d.DesignationId,
                             DepartmentId = d.DepartmentId,
                         };
            return result.ToList();
        }
    }
}