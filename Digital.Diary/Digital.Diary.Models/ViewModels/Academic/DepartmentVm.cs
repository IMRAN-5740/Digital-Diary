using Digital.Diary.Models.EntityModels.Academic;

namespace Digital.Diary.Models.ViewModels.Academic
{
    public class DepartmentVm
    {
        public Guid? Id { get; set; }
        public string DeptName { get; set; } = default!;
        public Guid FacultyId { get; set; }
        public string? FacultyName { get; set; }

        public Department ToModel()
        {
            return new Department()
            {
                DeptName = DeptName,
                FacultyId = FacultyId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}