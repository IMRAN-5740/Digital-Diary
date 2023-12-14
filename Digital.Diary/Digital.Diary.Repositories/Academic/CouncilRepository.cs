using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Repositories.Abstractions.Academic;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Academic
{
    public class CouncilRepository : Repository<Council>, ICouncilRepository
    {
        public CouncilRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Council GetFirstOrDefault(Expression<Func<Council, bool>> predicate)
        {
            return _dbContext.Set<Council>().FirstOrDefault(predicate);
        }

        public override ICollection<Council> GetAll(Expression<Func<Council, bool>>? predicate = null)
        {
            var result = from d in _dbContext.Set<Council>()
                         join f in _dbContext.Designations on d.DesignationId equals f.Id
                         select new Council
                         {
                             Id = d.Id,
                             Name = d.Name,
                             Email = d.Email,
                             PhoneNum = d.PhoneNum,
                             ProfileImage = d.ProfileImage,
                             DesignationId = d.DesignationId,
                         };
            return result.ToList();
        }
    }
}