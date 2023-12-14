using Digital.Diary.Models.BaseEntityModel;
using Digital.Diary.Models.EntityModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(Dean), Schema = "Academic")]
    public class Dean : BaseUserTable
    {

        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;

        public Designation Designation { get; set; } = default!;

        [DisplayName("Faculty Name")]
        public Guid FacultyId { get; set; } = default!;

        public Faculty Faculty { get; set; } = default!;
    }
}