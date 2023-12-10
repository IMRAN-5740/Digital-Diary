using Digital.Diary.Models.EntityModels.Academic;

namespace Digital.Diary.Models.ViewModels.Academic
{
    public class CouncilVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string? ProfileImage { get; set; }
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public Council ToModel()
        {
            return new Council()
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                DesignationId = DesignationId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}