using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Common;
using Digital.Diary.Models.ViewModels.Common;
using Digital.Diary.Repositories.Abstractions;
using Digital.Diary.Services.Abstractions;
using Digital.Diary.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Services
{
    public class DesignationService:Service<Designation>,IDesignationService
    {

        IDesignationRepository _repo;

        public DesignationService(IDesignationRepository repo) : base(repo)
        {
            _repo = repo;
        }
        public override Result Create(Designation entity)
        {
            
            var result = new Result();
            //code Designation
            var codeResult = _repo.GetAll(c => c.DesignationName == entity.DesignationName);
            if (codeResult.Any())
            {
                result.IsSucced = false;
                result.ErrorMessages.Add("Same Entity already exist.!");
            }


            if (result.ErrorMessages.Any())
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

