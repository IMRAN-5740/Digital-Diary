﻿using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Repositories.Abstractions.Academic;
using Digital.Diary.Repositories.Base;
using System.Linq.Expressions;

namespace Digital.Diary.Repositories.Academic
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Department GetFirstOrDefault(Expression<Func<Department, bool>> predicate)
        {
            return _dbContext.Set<Department>().FirstOrDefault(predicate);
        }

        public override ICollection<Department> GetAll(Expression<Func<Department, bool>>? predicate = null)
        {
            var result = from d in _dbContext.Set<Department>()
                         join f in _dbContext.Faculties on d.FacultyId equals f.Id
                         orderby d.Sequence
                         select new Department
                         {
                             Id = d.Id,
                             DeptName = d.DeptName,
                             Sequence = d.Sequence,
                             FacultyId = d.FacultyId
                         };
            return result.ToList();
        }
    }
}