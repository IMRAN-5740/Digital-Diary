using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class PostOfficeVm
    {
        public Guid? Id { get; set; }
        public string PostOfficeName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string PostCode { get; set; } = default!;
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public PostOffice ToModel()
        {
            return new PostOffice
            {
                PostOfficeName = PostOfficeName,
                Email = Email,
                PhoneNum = PhoneNum,
                PostCode = PostCode,
                DesignationId = DesignationId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}