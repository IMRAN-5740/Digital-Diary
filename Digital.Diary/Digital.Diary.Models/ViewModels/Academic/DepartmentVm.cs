using Digital.Diary.Models.EntityModels.Academic;

namespace Digital.Diary.Models.ViewModels.Academic
{
    public class DepartmentVm
    {
        public Guid? Id { get; set; }
        public string DeptName { get; set; } = default!;
        public int Sequence { get; set; }

        public Guid FacultyId { get; set; }
        public string? FacultyName { get; set; }
        public string? ShortName { get; set; }

        public Department ToModel()
        {
            return new Department()
            {
                DeptName = DeptName,
                Sequence = Sequence,
                FacultyId = FacultyId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}