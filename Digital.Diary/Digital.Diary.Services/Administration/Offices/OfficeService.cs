using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Administration.Offices;
using Digital.Diary.Repositories.Abstractions.Administration.Offices;
using Digital.Diary.Services.Abstractions.Administration.Offices;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services.Administration.Offices
{
    public class OfficeService : Service<Office>, IOfficeService
    {
        private readonly IOfficeRepository _repo;

        public OfficeService(IOfficeRepository repository) : base(repository)
        {
            _repo = repository;
        }

        public override Result Create(Office entity)
        {
            var result = new Result();
            //code Designation
            var checkEntity = _repo.GetAll(c => c.OfficeName == entity.OfficeName);
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

        public override Result Update(Office entity)
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

        public override Result Remove(Office entity)
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