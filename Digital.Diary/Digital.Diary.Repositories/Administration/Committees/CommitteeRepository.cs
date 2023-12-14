using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Repositories.Abstractions.Administration.Committees;
using Digital.Diary.Repositories.Base;

namespace Digital.Diary.Repositories.Administration.Committees
{
    public class CommitteeRepository : Repository<Committee>, ICommitteeRepository
    {
        public CommitteeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}