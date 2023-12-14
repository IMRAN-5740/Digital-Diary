using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Repositories.Abstractions;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories
{
    public class DeanRepository : Repository<Dean>, IDeanRepository
    {
        public DeanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Dean GetFirstOrDefault(Expression<Func<Dean, bool>> predicate)
        {
            return _dbContext.Set<Dean>().FirstOrDefault(predicate);
        }

        public override ICollection<Dean> GetAll(Expression<Func<Dean, bool>>? predicate = null)
        {
            var result = from d in _dbContext.Set<Dean>()
                         join f in _dbContext.Faculties on d.FacultyId equals f.Id
                         select new Dean
                         {
                             Id = d.Id,
                             Name = d.Name,
                             Email = d.Email,
                             PhoneNum = d.PhoneNum,
                             ProfileImage = d.ProfileImage,
                             DesignationId = d.DesignationId,
                             FacultyId = d.FacultyId,
                         };
            return result.ToList();
        }
    }
}