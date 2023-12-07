using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(District), Schema = "EmergencyServices")]
    public class District : BaseEmergencyModel
    {
        public string DistrictName { get; set; } = default!;
    }
}