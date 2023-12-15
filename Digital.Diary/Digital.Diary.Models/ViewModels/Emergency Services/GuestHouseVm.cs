using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class GuestHouseVm
    {
        public Guid? Id { get; set; }
        public string HouseName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;

        public GuestHouse ToModel()
        {
            return new GuestHouse
            {
                HouseName = HouseName,
                Email = Email,
                PhoneNum = PhoneNum,
                Id = Id ?? Guid.Empty
            };
        }
    }
}