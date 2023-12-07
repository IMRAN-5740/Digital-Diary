using Digital.Diary.Models.BaseEntityModel;
using Digital.Diary.Models.EntityModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Student_Activities.Clubs
{
    [Table(nameof(ClubEmployee), Schema = "StudentActivities.Clubs")]
    public class ClubEmployee : BaseUserTable
    {
        [DisplayName("Club Name")]
        public Guid ClubId { get; set; } = default!;

        public Club Club { get; set; } = default!;

        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;

        public Designation Designation { get; set; } = default!;
    }
}