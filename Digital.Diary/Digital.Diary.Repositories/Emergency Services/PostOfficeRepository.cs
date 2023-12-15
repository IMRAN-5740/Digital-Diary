using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Repositories.Abstractions.Emergency_Services;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Emergency_Services
{
    public class PostOfficeRepository : Repository<PostOffice>, IPostOfficeRepository
    {
        public PostOfficeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override PostOffice GetFirstOrDefault(Expression<Func<PostOffice, bool>> predicate)
        {
            return _dbContext.Set<PostOffice>().FirstOrDefault(predicate);
        }

        public override ICollection<PostOffice> GetAll(Expression<Func<PostOffice, bool>>? predicate = null)
        {
            var result = from d in _dbContext.Set<PostOffice>()
                         join f in _dbContext.Designations on d.DesignationId equals f.Id
                         select new PostOffice
                         {
                             Id = d.Id,
                             PostOfficeName = d.PostOfficeName,
                             Email = d.Email,
                             PhoneNum = d.PhoneNum,
                             DesignationId = d.DesignationId,
                         };
            return result.ToList();
        }
    }
}