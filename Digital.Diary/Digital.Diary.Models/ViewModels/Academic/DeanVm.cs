using Digital.Diary.Models.EntityModels.Academic;

namespace Digital.Diary.Models.ViewModels.Academic
{
    public class DeanVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string? ProfileImage { get; set; }
        public Guid FacultyId { get; set; }
        public string? FacultyName { get; set; }

        public Dean ToModel()
        {
            return new Dean()
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                FacultyId = FacultyId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}