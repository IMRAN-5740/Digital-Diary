using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(Courier), Schema = "EmergencyServices")]
    public class Courier : BaseEmergencyModel
    {
        public string CourierName { get; set; } = default!;
    }
}