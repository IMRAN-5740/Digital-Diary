using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Offices;
using Digital.Diary.Repositories.Abstractions.Administration.Offices;
using Digital.Diary.Repositories.Base;

namespace Digital.Diary.Repositories.Administration.Offices
{
    public class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}