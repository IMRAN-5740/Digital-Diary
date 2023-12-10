using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Repositories.Abstractions;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Teacher GetFirstOrDefault(Expression<Func<Teacher, bool>> predicate)
        {
            return _dbContext.Set<Teacher>().FirstOrDefault(predicate);
        }

        public override ICollection<Teacher> GetAll(Expression<Func<Teacher, bool>>? predicate = null)
        {
            var result = from t in _dbContext.Set<Teacher>()
                         join d in _dbContext.Designations on t.DesignationId equals d.Id
                         join de in _dbContext.Departments on t.DepartmentId equals de.Id
                         join f in _dbContext.Faculties on t.FacultyId equals f.Id
                         select new Teacher
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Email = t.Email,
                             PhoneNum = t.PhoneNum,
                             ProfileImage = t.ProfileImage,

                             DesignationId = d.Id,
                             DepartmentId = de.Id,
                             FacultyId = f.Id,
                         };
            return result.ToList();
        }
    }
}