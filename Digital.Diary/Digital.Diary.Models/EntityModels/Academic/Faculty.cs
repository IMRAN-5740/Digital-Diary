using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(Faculty), Schema = "Academic")]
    public class Faculty
    {
        public Faculty()
        {
            TeacherFaculties = new List<TeacherFaculty>();
        }

        public Guid Id { get; set; }

        [DisplayName("Faculty Name")]
        public string FacultyName { get; set; } = default!;
        public virtual ICollection<TeacherFaculty> TeacherFaculties { get; set; }
    }
}