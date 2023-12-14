using Digital.Diary.Models.EntityModels.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Academic
{
    public class CrTableVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;

        public string? ProfileImage { get; set; }
        public string Year { get; set; } = default!;
        public Guid DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public CrTable ToModel()
        {
            return new CrTable()
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                Year = Year,
                DepartmentId = DepartmentId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}
