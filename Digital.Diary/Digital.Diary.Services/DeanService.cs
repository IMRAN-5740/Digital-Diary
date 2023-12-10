using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Repositories.Abstractions;
using Digital.Diary.Services.Abstractions;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services
{
    public class DeanService : Service<Dean>, IDeanService
    {
        private IDeanRepository _repo;
        private IFacultyRepository _facRepo;

        public DeanService(IDeanRepository repo, IFacultyRepository facRepo) : base(repo)
        {
            _repo = repo;
            _facRepo = facRepo;
        }

        public override Result Create(Dean entity)
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

        public override Result Update(Dean entity)
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

        public override Result Remove(Dean entity)
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