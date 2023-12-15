using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class FireStationVm
    {
        public Guid? Id { get; set; }
        public string FireStationName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;

        public FireStation ToModel()
        {
            return new FireStation
            {
                FireStationName = FireStationName,
                Email = Email,
                PhoneNum = PhoneNum,
                Id = Id ?? Guid.Empty
            };
        }
    }
}