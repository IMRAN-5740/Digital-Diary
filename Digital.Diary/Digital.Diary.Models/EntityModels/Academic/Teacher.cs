using Digital.Diary.Models.BaseEntityModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(Teacher), Schema = "Academic")]
    public class Teacher : BaseUserTable
    {


        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;

        public Designation Designation { get; set; } = default!;

        [DisplayName("Faculty Name")]
        public Guid FacultyId { get; set; } = default!;

        public Faculty Faculty { get; set; } = default!;

        [DisplayName("Department Name")]
        public Guid DepartmentId { get; set; } = default!;

        public Department Department { get; set; } = default!;

    }
}