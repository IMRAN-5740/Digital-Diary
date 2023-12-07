using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(AnsarForce), Schema = "EmergencyServices")]
    public class AnsarForce : BaseEmergencyModel
    {
        public string AnsarStationName { get; set; } = default!;
    }
}