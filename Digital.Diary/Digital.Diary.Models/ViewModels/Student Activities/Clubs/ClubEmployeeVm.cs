using Digital.Diary.Models.EntityModels.Student_Activities.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Student_Activities.Clubs
{
    public class ClubEmployeeVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;

        public string? ProfileImage { get; set; }
        public Guid ClubId { get; set; }
        public string? ClubName { get; set; }
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public ClubEmployee ToModel()
        {
            return new ClubEmployee
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                ClubId = ClubId,
                DesignationId = DesignationId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}