using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(Train), Schema = "EmergencyServices")]
    public class Train
    {
        public Guid Id { get; set; } = default!;
        public string TrainName { get; set; } = default!;
        public string StartingPoint { get; set; } = default!;
        public string EndingPoint { get; set; } = default!;
        public string? TrainDescription { get; set; }
    }
}