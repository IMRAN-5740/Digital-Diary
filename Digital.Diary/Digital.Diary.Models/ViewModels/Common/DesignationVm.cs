using Digital.Diary.Models.EntityModels.Common;

namespace Digital.Diary.Models.ViewModels.Common
{
    public class DesignationVm
    {
        public Guid? Id { get; set; }
        public string DesignationName { get; set; } = default!;

        public Designation ToModel()
        {
            return new Designation
            {
                DesignationName = DesignationName,
                Id = Id ?? Guid.Empty
            };
        }
    }
}