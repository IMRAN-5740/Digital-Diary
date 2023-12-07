using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Common;
using Digital.Diary.Models.ViewModels.Common;
using Digital.Diary.Repositories.Abstractions;
using Digital.Diary.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Repositories
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        public DesignationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext=dbContext;
        }
    }
}
