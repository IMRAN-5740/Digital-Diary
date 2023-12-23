using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.AppServer.Models.Academic
{
    public class Department
    {
        public Guid Id { get; set; }
        public string DeptName { get; set; } = default!;
        public string? FacultyName { get; set; }
        public int Sequence { get; set; }
        public string? ImagePath { get; set; }
    }
}