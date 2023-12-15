using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Repositories.Abstractions.Emergency_Services;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Emergency_Services
{
    public class PoliceStationRepository : Repository<PoliceStation>, IPoliceStationRepository
    {
        public PoliceStationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override PoliceStation GetFirstOrDefault(Expression<Func<PoliceStation, bool>> predicate)
        {
            return _dbContext.Set<PoliceStation>().FirstOrDefault(predicate);
        }

        public override ICollection<PoliceStation> GetAll(Expression<Func<PoliceStation, bool>>? predicate = null)
        {
            var result = from d in _dbContext.Set<PoliceStation>()
                         join f in _dbContext.Designations on d.DesignationId equals f.Id
                         select new PoliceStation
                         {
                             Id = d.Id,
                             StationName = d.StationName,
                             Email = d.Email,
                             PhoneNum = d.PhoneNum,
                             DesignationId = d.DesignationId,
                         };
            return result.ToList();
        }
    }
}