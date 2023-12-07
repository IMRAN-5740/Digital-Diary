using Digital.Diary.Models.BaseEntityModel;
using Digital.Diary.Models.EntityModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Administration.Committees
{
    [Table(nameof(CommitteeEmployee), Schema = "Administration.Committees")]
    public class CommitteeEmployee : BaseUserTable
    {
        [DisplayName("Committee Name")]
        public Guid CommitteeId { get; set; } = default!;

        public Committee Committee { get; set; } = default!;

        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;

        public Designation Designation { get; set; } = default!;
    }
}