using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Repositories.Abstractions.Emergency_Services;
using Digital.Diary.Repositories.Base;

namespace Digital.Diary.Repositories.Emergency_Services
{
    public class AmbulanceRepository : Repository<Ambulance>, IAmbulanceRepository
    {
        public AmbulanceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}