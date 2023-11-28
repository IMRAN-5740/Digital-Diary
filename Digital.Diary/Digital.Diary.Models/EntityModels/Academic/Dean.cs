using Digital.Diary.Models.BaseEntityModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(Dean), Schema = "Academic")]
    public class Dean : BaseUserTable
    {
        [DisplayName("Faculty Name")]
        public Guid FacultyId { get; set; } = default!;
        public Faculty Faculty { get; set; } = default!;
    }
}