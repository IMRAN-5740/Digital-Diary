using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class PoliceStationVm
    {
        public Guid? Id { get; set; }
        public string StationName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public PoliceStation ToModel()
        {
            return new PoliceStation
            {
                StationName = StationName,
                Email = Email,
                PhoneNum = PhoneNum,
                DesignationId = DesignationId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}