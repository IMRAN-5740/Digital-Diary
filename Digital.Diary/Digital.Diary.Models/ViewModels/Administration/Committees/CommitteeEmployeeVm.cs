using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Models.EntityModels.Administration.Committees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Administration.Committees
{
    public class CommitteeEmployeeVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string? ProfileImage { get; set; }
        public Guid CommitteeId { get; set; }
        public string? CommitteeName { get; set; }
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public CommitteeEmployee ToModel()
        {
            return new CommitteeEmployee
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                CommitteeId = CommitteeId,
                DesignationId= DesignationId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}
