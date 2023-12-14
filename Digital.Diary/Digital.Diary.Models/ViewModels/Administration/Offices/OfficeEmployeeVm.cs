using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Models.EntityModels.Administration.Offices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Administration.Offices
{
    public class OfficeEmployeeVm
    {

        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string? ProfileImage { get; set; }
        public Guid OfficeId { get; set; }
        public string? OfficeName { get; set; }
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public OfficeEmployee ToModel()
        {
            return new OfficeEmployee
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                OfficeId = OfficeId,
                DesignationId = DesignationId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}
