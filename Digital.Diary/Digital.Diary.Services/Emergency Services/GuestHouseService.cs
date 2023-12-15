using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Repositories.Abstractions.Emergency_Services;
using Digital.Diary.Services.Abstractions.Emergency_Services;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services.Emergency_Services
{
    public class GuestHouseService : Service<GuestHouse>, IGuestHouseService
    {
        private readonly IGuestHouseRepository _repo;

        public GuestHouseService(IGuestHouseRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public override Result Create(GuestHouse entity)
        {
            var result = new Result();
            //code Designation
            var checkEntity = _repo.GetAll(c => c.HouseName == entity.HouseName);
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

        public override Result Update(GuestHouse entity)
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

        public override Result Remove(GuestHouse entity)
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