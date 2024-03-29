﻿using Digital.Diary.Databases.Data;
using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Repositories.Abstractions.Administration.Transportations;
using Digital.Diary.Repositories.Base;

namespace Digital.Diary.Repositories.Administration.Transportation
{
    public class TransportRepository : Repository<Transport>, ITransportRepository
    {
        public TransportRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}