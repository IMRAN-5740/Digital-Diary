using Digital.Diary.Models.BaseEntityModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(CrTable), Schema = "Academic")]
    public class CrTable : BaseUserTable
    {
        [DisplayName("Session")]
        public string Year { get; set; } = default!;

        [DisplayName("Department Name")]
        public Guid DepartmentId { get; set; } = default!;

        public Department Department { get; set; } = default!;
    }
}
