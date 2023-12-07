using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(FireStation), Schema = "EmergencyServices")]
    public class FireStation : BaseEmergencyModel
    {
        [DisplayName("Fire Station")]
        public string FireStationName { get; set; } = default!;
    }
}