using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class BusVm
    {
        public Guid? Id { get; set; }
        public string BusName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string StartingPoint { get; set; } = default!;
        public string EndingPoint { get; set; } = default!;

        public Bus ToModel()
        {
            return new Bus
            {
                BusName = BusName,
                Email = Email,
                PhoneNum = PhoneNum,
                StartingPoint = StartingPoint,
                EndingPoint = EndingPoint,
                Id = Id ?? Guid.Empty
            };
        }
    }
}