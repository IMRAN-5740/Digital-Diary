using Digital.Diary.Models.EntityModels.Student_Activities.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Student_Activities.Clubs
{
    public class ClubVm
    {
        public Guid? Id { get; set; }
        public string ClubName { get; set; } = default!;
        public string? Description { get; set; }

        public Club ToModel()
        {
            return new Club
            {
                ClubName = ClubName,
                Description = Description,
                Id = Id ?? Guid.Empty
            };
        }
    }
}