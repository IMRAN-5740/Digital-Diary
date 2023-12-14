using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Repositories.Abstractions.Administration.Associations;
using Digital.Diary.Services.Abstractions.Administration.Associations;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services.Administration.Associations
{
    public class AssociationEmployeeService : Service<AssociationEmployee>, IAssociationEmployeeService
    {
        private readonly IAssociationEmployeeRepository _repo;

        public AssociationEmployeeService(IAssociationEmployeeRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public override Result Create(AssociationEmployee entity)
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

        public override Result Update(AssociationEmployee entity)
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

        public override Result Remove(AssociationEmployee entity)
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