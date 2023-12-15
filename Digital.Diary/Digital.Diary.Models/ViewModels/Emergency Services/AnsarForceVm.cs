using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class AnsarForceVm
    {
        public Guid? Id { get; set; }
        public string AnsarStationName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;

        public AnsarForce ToModel()
        {
            return new AnsarForce
            {
                AnsarStationName = AnsarStationName,
                Email = Email,
                PhoneNum = PhoneNum,
                Id = Id ?? Guid.Empty
            };
        }
    }
}