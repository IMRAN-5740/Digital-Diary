using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class TrainVm
    {
        public Guid? Id { get; set; }
        public string TrainName { get; set; } = default!;
        public string StartingPoint { get; set; } = default!;
        public string EndingPoint { get; set; } = default!;
        public string? TrainDescription { get; set; }

        public Train ToModel()
        {
            return new Train
            {
                TrainName = TrainName,
                StartingPoint = StartingPoint,
                EndingPoint = EndingPoint,
                TrainDescription = TrainDescription,
                Id = Id ?? Guid.Empty,
            };
        }
    }
}