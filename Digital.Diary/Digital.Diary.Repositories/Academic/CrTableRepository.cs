using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Repositories.Abstractions.Academic;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Academic
{
    public class CrTableRepository : Repository<CrTable>, ICrTableRepository
    {
        public CrTableRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override CrTable GetFirstOrDefault(Expression<Func<CrTable, bool>> predicate)
        {
            return _dbContext.Set<CrTable>().FirstOrDefault(predicate);
        }

        public override ICollection<CrTable> GetAll(Expression<Func<CrTable, bool>>? predicate = null)
        {
            var result = from d in _dbContext.Set<CrTable>()
                         join f in _dbContext.Departments on d.DepartmentId equals f.Id
                         select new CrTable
                         {
                             Id = d.Id,
                             Name = d.Name,
                             Email = d.Email,
                             PhoneNum = d.PhoneNum,
                             ProfileImage = d.ProfileImage,
                             DepartmentId = d.DepartmentId,
                         };
            return result.ToList();
        }
    }
}