using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Repositories.Abstractions.Administration.Transportations;
using Digital.Diary.Services.Abstractions.Administration.Transportation;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services.Administration.Transportation
{
    public class TransportEmployeeService : Service<TransportEmployee>, ITransportEmployeeService
    {
        private readonly ITransportEmployeeRepository _repo;

        public TransportEmployeeService(ITransportEmployeeRepository repository) : base(repository)
        {
            _repo = repository;
        }

        public override Result Create(TransportEmployee entity)
        {
            var result = new Result();
            //code Designation
            var checkEntity = _repo.GetAll(c => c.Name == entity.Name);
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

        public override Result Update(TransportEmployee entity)
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

        public override Result Remove(TransportEmployee entity)
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