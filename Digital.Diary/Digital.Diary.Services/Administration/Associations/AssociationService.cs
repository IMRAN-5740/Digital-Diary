using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Repositories.Abstractions.Administration.Associations;
using Digital.Diary.Services.Abstractions.Administration.Associations;
using Digital.Diary.Services.Base;

namespace Digital.Diary.Services.Administration.Associations
{
    public class AssociationService : Service<Association>, IAssociationService
    {
        private readonly IAssociationRepository _repo;

        public AssociationService(IAssociationRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public override Result Create(Association entity)
        {
            var result = new Result();
            //code Designation
            var checkEntity = _repo.GetAll(c => c.AssociationName == entity.AssociationName);
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

        public override Result Update(Association entity)
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

        public override Result Remove(Association entity)
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