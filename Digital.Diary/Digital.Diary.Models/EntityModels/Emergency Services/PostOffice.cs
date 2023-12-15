using Digital.Diary.Models.EntityModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    [Table(nameof(PostOffice), Schema = "EmergencyServices")]
    public class PostOffice : BaseEmergencyModel
    {
        public string PostOfficeName { get; set; } = default!;
        public string PostCode { get; set; } = default!;

        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;

        public Designation Designation { get; set; } = default!;
    }
}