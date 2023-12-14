using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Repositories.Abstractions.Administration.Committees;
using Digital.Diary.Services.Abstractions.Administration.Committees;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services.Administration.Committees
{
    public class CommitteeEmployeeService : Service<CommitteeEmployee>, ICommitteeEmployeeService
    {
        private readonly ICommitteeEmployeeRepository _repo;

        public CommitteeEmployeeService(ICommitteeEmployeeRepository repository) : base(repository)
        {
            _repo = repository;
        }

        public override Result Create(CommitteeEmployee entity)
        {
            var result = new Result();
            entity.Id = Guid.NewGuid();
            //code Designation
            var checkEntity = _repo.GetFirstOrDefault(c => c.Name == entity.Name);
            if (checkEntity != null)
            {
                result.IsSucced = false;
                result.ErrorMessages.Add("Same Entity already exist.!");
            }

            if (result.ErrorMessages.Count != 0)
            {
                return result;
            }
            bool isSuccess = _repo.Create(entity);
            if (isSuccess)
            {
                result.IsSucced = true;
                return result;
            }
            result.ErrorMessages.Add("Entity not Created");
            return result;
        }

        public override Result Update(CommitteeEmployee entity)
        {
            var result = new Result();
            bool isSuccess = _repo.Update(entity);
            if (isSuccess)
            {
                result.IsSucced = true;
                return result;
            }
            result.ErrorMessages.Add("Entity not Updated");
            return result;
        }

        public override Result Remove(CommitteeEmployee entity)
        {
            var result = new Result();
            bool isSuccess = _repo.Remove(entity);
            if (isSuccess)
            {
                result.IsSucced = true;
                return result;
            }

            result.ErrorMessages.Add("Entity not Removed");

            return result;
        }
    }
}