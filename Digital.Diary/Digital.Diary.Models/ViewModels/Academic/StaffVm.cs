using Digital.Diary.Models.EntityModels.Academic;

namespace Digital.Diary.Models.ViewModels.Academic
{
    public class StaffVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string? ProfileImage { get; set; }

        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; } 
        public Guid DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public Staff ToModel()
        {
            return new Staff()
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                DesignationId = DesignationId,
                DepartmentId = DepartmentId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}