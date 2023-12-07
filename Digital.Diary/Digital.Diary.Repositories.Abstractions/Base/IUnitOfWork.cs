using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Repositories.Abstractions.Base
{
    public interface IUnitOfWork
    {
        IDesignationRepository Designation { get; }
        void Save();
    }
}
