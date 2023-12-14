using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Common;
using Digital.Diary.Repositories.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services.Academic
{
    public class DesignationService : Service<Designation>, IDesignationService
    {
        private readonly IDesignationRepository _repo;

        public DesignationService(IDesignationRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public override Result Create(Designation entity)
        {
            var result = new Result();
            //code Designation
            var checkEntity = _repo.GetAll(c => c.DesignationName == entity.DesignationName);
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

        public override Result Update(Designation entity)
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

        public override Result Remove(Designation entity)
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