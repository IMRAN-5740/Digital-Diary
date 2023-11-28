using Digital.Diary.Models.BaseEntityModel;
using Digital.Diary.Models.EntityModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(Staff), Schema = "Academic")]
    public class Staff:BaseUserTable
    {

        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;
        public Designation Designation { get; set; } = default!;


        [DisplayName("Department Name")]
        public Guid DepartmentId { get; set; } = default!;
        public Department Department { get; set; } = default!;
    }
}
