using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(GuestHouse), Schema = "EmergencyServices")]
    public class GuestHouse : BaseEmergencyModel
    {
        public string HouseName { get; set; } = default!;
    }
}