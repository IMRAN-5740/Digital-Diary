using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Common;
using Digital.Diary.Repositories.Abstractions.Academic;
using Digital.Diary.Repositories.Base;

namespace Digital.Diary.Repositories.Academic
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        public DesignationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}