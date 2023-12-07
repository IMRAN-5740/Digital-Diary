using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Common;
using Digital.Diary.Repositories.Abstractions;
using Digital.Diary.Repositories.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            Designation = new  DesignationRepository(_dbContext);
        }
        public IDesignationRepository Designation { get; private set; }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
