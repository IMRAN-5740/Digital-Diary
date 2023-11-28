using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(Faculty), Schema = "Academic")]
    public class Faculty
    {
        public Guid Id { get; set; }

        [DisplayName("Faculty Name")]
        public string FacultyName { get; set; } = default!;

        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<Dean> Deans { get; set; } = new List<Dean>();
    }
}