using Digital.Diary.Models.EntityModels.Administration.Transportation;

namespace Digital.Diary.Models.ViewModels.Administration.Transportations
{
    public class TransportVm
    {
        public Guid? Id { get; set; }
        public string BusName { get; set; } = default!;

        public string StartingPoint { get; set; } = default!;
        public string EndingPoint { get; set; } = default!;

        public Transport ToModel()
        {
            return new Transport
            {
                BusName = BusName,
                StartingPoint = StartingPoint,
                EndingPoint = EndingPoint,
                Id = Id ?? Guid.Empty
            };
        }
    }
}