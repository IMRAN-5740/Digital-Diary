using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Offices;
using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Repositories.Abstractions.Administration.Transportations;
using Digital.Diary.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Repositories.Administration.Transportation
{
    public class TransportEmployeeRepository : Repository<TransportEmployee>, ITransportEmployeeRepository
    {
        public TransportEmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override TransportEmployee GetFirstOrDefault(Expression<Func<TransportEmployee, bool>> predicate)
        {
            return _dbContext.Set<TransportEmployee>().FirstOrDefault(predicate);
        }

        public override ICollection<TransportEmployee> GetAll(Expression<Func<TransportEmployee, bool>>? predicate = null)
        {
            var result = from t in _dbContext.Set<TransportEmployee>()
                         join d in _dbContext.Designations on t.DesignationId equals d.Id
                         join to in _dbContext.Transports on t.TransportId equals to.Id
                         select new TransportEmployee
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Email = t.Email,
                             PhoneNum = t.PhoneNum,
                             ProfileImage = t.ProfileImage,
                             DesignationId = d.Id,
                             TransportId = to.Id,
                         };
            return result.ToList();
        }
    }
}
