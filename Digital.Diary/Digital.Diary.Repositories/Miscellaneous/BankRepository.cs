using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Miscellaneous;
using Digital.Diary.Repositories.Abstractions.Miscellaneous;
using Digital.Diary.Repositories.Base;

namespace Digital.Diary.Repositories.Miscellaneous
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}