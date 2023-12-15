using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Student_Activities.Clubs;
using Digital.Diary.Repositories.Abstractions.Student_Activities.Clubs;
using Digital.Diary.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Repositories.Student_Activities.Clubs
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        public ClubRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}