using Digital.Diary.Models.EntityModels.Miscellaneous;
using Digital.Diary.Models;
using Digital.Diary.Models.EntityModels.Student_Activities.Clubs;
using Digital.Diary.Repositories.Abstractions.Base;
using Digital.Diary.Repositories.Abstractions.Student_Activities.Clubs;
using Digital.Diary.Services.Abstractions.Student_Activities.Clubs;
using Digital.Diary.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Services.Student_Activities.Clubs
{
    public class ClubEmployeeService : Service<ClubEmployee>, IClubEmployeeService
    {
        private readonly IClubEmployeeRepository _repo;

        public ClubEmployeeService(IClubEmployeeRepository repository) : base(repository)
        {
            _repo = repository;
        }

        public override Result Create(ClubEmployee entity)
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

        public override Result Update(ClubEmployee entity)
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

        public override Result Remove(ClubEmployee entity)
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