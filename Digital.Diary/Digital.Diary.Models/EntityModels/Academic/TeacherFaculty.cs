using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(TeacherFaculty), Schema = "Academic")]

    public class TeacherFaculty
    {
        public Guid Id { get; set; }

       

        [DisplayName("Teacher")]
        public Guid TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; } = default!;



        [DisplayName("Faculty")]
        public Guid FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }= default!;
    }
}
