using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(Ambulance), Schema = "EmergencyServices")]
    public class Ambulance : BaseEmergencyModel
    {
        public string AmbulanceName { get; set; } = default!;
    }
}