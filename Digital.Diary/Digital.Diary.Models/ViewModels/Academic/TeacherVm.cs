using Digital.Diary.Models.EntityModels.Academic;

namespace Digital.Diary.Models.ViewModels.Academic
{
    public class TeacherVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string? ProfileImage { get; set; }
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public Guid FacultyId { get; set; }
        public string? FacultyName { get; set; }
        public Guid DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public Teacher ToModel()
        {
            return new Teacher()
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                DesignationId = DesignationId,
                FacultyId = FacultyId,
                DepartmentId = DepartmentId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}