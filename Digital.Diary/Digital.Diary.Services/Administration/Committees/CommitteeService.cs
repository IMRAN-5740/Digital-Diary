using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Repositories.Abstractions.Administration.Committees;
using Digital.Diary.Services.Abstractions.Administration.Committees;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services.Administration.Committees
{
    public class CommitteeService : Service<Committee>, ICommitteeService
    {
        private readonly ICommitteeRepository _repo;

        public CommitteeService(ICommitteeRepository repository) : base(repository)
        {
            _repo = repository;
        }

        public override Result Create(Committee entity)
        {
            var result = new Result();
            //code Designation
            var checkEntity = _repo.GetAll(c => c.CommitteeName == entity.CommitteeName);
            if (checkEntity.Count != 0)
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

        public override Result Update(Committee entity)
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

        public override Result Remove(Committee entity)
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