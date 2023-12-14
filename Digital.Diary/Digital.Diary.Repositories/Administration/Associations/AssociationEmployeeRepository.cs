using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Repositories.Abstractions.Administration.Associations;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Administration.Associations
{
    public class AssociationEmployeeRepository : Repository<AssociationEmployee>, IAssociationEmployeeRepository
    {
        public AssociationEmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override AssociationEmployee GetFirstOrDefault(Expression<Func<AssociationEmployee, bool>> predicate)
        {
            return _dbContext.Set<AssociationEmployee>().FirstOrDefault(predicate);
        }

        public override ICollection<AssociationEmployee> GetAll(Expression<Func<AssociationEmployee, bool>>? predicate = null)
        {
            var result = from t in _dbContext.Set<AssociationEmployee>()
                         join d in _dbContext.Designations on t.DesignationId equals d.Id
                         join de in _dbContext.Associations on t.AssociationId equals de.Id
                         select new AssociationEmployee
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Email = t.Email,
                             PhoneNum = t.PhoneNum,
                             ProfileImage = t.ProfileImage,
                             DesignationId = d.Id,
                             AssociationId = de.Id,
                         };
            return result.ToList();
        }
    }
}