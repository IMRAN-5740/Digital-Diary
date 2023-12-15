using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class DistrictVm
    {
        public Guid? Id { get; set; }
        public string DistrictName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;

        public District ToModel()
        {
            return new District
            {
                DistrictName = DistrictName,
                Email = Email,
                PhoneNum = PhoneNum,
                Id = Id ?? Guid.Empty
            };
        }
    }
}