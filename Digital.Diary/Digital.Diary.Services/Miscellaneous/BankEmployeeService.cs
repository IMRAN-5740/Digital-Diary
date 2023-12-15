using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Miscellaneous;
using Digital.Diary.Repositories.Abstractions.Administration.Transportations;
using Digital.Diary.Services.Abstractions.Miscellaneous;
using Digital.Diary.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital.Diary.Repositories.Abstractions.Miscellaneous;

namespace Digital.Diary.Services.Miscellaneous
{
    public class BankEmployeeService : Service<BankEmployee>, IBankEmployeeService
    {
        private readonly IBankEmployeeRepository _repo;

        public BankEmployeeService(IBankEmployeeRepository repository) : base(repository)
        {
            _repo = repository;
        }

        public override Result Create(BankEmployee entity)
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

        public override Result Update(BankEmployee entity)
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

        public override Result Remove(BankEmployee entity)
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