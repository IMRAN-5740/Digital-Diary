using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(Bus), Schema = "EmergencyServices")]
    public class Bus : BaseEmergencyModel
    {
        public string BusName { get; set; } = default!;
        public string StartingPoint { get; set; } = default!;
        public string EndingPoint { get; set; } = default!;
    }
}