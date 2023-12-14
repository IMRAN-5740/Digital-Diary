using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Repositories.Abstractions.Administration.Committees;
using Digital.Diary.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
