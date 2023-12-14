using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Repositories.Abstractions.Academic;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Academic
{
    public class RegentBoardRepository : Repository<RegentBoard>, IRegentBoardRepository
    {
        public RegentBoardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override RegentBoard GetFirstOrDefault(Expression<Func<RegentBoard, bool>> predicate)
        {
            return _dbContext.Set<RegentBoard>().FirstOrDefault(predicate);
        }

        public override ICollection<RegentBoard> GetAll(Expression<Func<RegentBoard, bool>>? predicate = null)
        {
            var result = from d in _dbContext.Set<RegentBoard>()
                         join f in _dbContext.Designations on d.DesignationId equals f.Id
                         select new RegentBoard
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