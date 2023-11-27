using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(Department), Schema = "Academic")]
    public class Department
    {
        public Guid Id { get; set; }

        public string DeptName { get; set; } = default!;

        [DisplayName("Faculty Name")]
        public Guid FacultyId { get; set; } = default!;

        public Faculty Faculty { get; set; } = default!;

    }
}
