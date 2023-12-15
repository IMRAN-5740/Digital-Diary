using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class AmbulanceVm
    {
        public Guid? Id { get; set; }
        public string AmbulanceName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;

        public Ambulance ToModel()
        {
            return new Ambulance
            {
                AmbulanceName = AmbulanceName,
                Email = Email,
                PhoneNum = PhoneNum,
                Id = Id ?? Guid.Empty
            };
        }
    }
}