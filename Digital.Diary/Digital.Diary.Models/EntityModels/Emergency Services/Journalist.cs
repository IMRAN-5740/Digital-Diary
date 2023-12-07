using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(Journalist), Schema = "EmergencyServices")]
    public class Journalist : BaseEmergencyModel
    {
        public string JournalName { get; set; } = default!;
    }
}