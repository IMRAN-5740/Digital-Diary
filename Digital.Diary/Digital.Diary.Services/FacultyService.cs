using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Repositories.Abstractions;
using Digital.Diary.Services.Abstractions;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services
{
    public class FacultyService : Service<Faculty>, IFacultyService
    {
        private IFacultyRepository _repo;

        public FacultyService(IFacultyRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public override Result Create(Faculty entity)
        {
            var result = new Result();
            //code Designation
            var checkEntity = _repo.GetAll(c => c.FacultyName == entity.FacultyName);
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

        public override Result Update(Faculty entity)
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

        public override Result Remove(Faculty entity)
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