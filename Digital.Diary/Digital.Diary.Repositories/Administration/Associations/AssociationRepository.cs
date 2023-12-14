using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Repositories.Abstractions.Administration.Associations;
using Digital.Diary.Repositories.Base;

namespace Digital.Diary.Repositories.Administration.Associations
{
    public class AssociationRepository : Repository<Association>, IAssociationRepository
    {
        public AssociationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}