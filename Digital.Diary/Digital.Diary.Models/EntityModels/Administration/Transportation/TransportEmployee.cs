using Digital.Diary.Models.BaseEntityModel;
using Digital.Diary.Models.EntityModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Administration.Transportation
{
    [Table(nameof(TransportEmployee), Schema = "Administration.Transportation")]
    public class TransportEmployee : BaseUserTable
    {
        [DisplayName("Transport Name")]
        public Guid TransportId { get; set; } = default!;

        public Transport Transport { get; set; } = default!;

        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;

        public Designation Designation { get; set; } = default!;
    }
}