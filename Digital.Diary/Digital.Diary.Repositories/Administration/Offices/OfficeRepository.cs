using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Offices;
using Digital.Diary.Repositories.Abstractions.Administration.Offices;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Administration.Offices
{
    public class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Office GetFirstOrDefault(Expression<Func<Office, bool>> predicate)
        {
            return _dbContext.Set<Office>().OrderBy(data=>data.OfficeLevel).FirstOrDefault(predicate);
        }
        public override ICollection<Office> GetAll(Expression<Func<Office, bool>>? predicate = null)
        {
            var result = from d in _dbContext.Set<Office>()
                         orderby d.OfficeLevel
                         select new Office
                         {
                             Id = d.Id,
                             OfficeName = d.OfficeName,
                             OfficeLevel = d.OfficeLevel,
                         };
            return result.ToList();
        }
    }
}