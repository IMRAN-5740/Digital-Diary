using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Repositories.Abstractions.Emergency_Services;
using Digital.Diary.Services.Abstractions.Emergency_Services;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services.Emergency_Services
{
    public class PoliceStationService : Service<PoliceStation>, IPoliceStationService
    {
        private readonly IPoliceStationRepository _repo;

        public PoliceStationService(IPoliceStationRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public override Result Create(PoliceStation entity)
        {
            var result = new Result();
            //code Designation
            var checkEntity = _repo.GetAll(c => c.StationName == entity.StationName);
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

        public override Result Update(PoliceStation entity)
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

        public override Result Remove(PoliceStation entity)
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