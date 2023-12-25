using Digital.Diary.Models.EntityModels.Administration.Offices;

namespace Digital.Diary.Models.ViewModels.Administration.Offices
{
    public class OfficeVm
    {
        public Guid? Id { get; set; }
        public string OfficeName { get; set; } = default!;
        public int OfficeLevel { get; set; }

        public Office ToModel()
        {
            return new Office
            {
                OfficeName = OfficeName,
                OfficeLevel = OfficeLevel,
                Id = Id ?? Guid.Empty
            };
        }
    }
}