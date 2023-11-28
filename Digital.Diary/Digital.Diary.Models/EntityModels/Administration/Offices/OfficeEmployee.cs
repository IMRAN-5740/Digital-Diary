using Digital.Diary.Models.BaseEntityModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Administration.Offices
{
    [Table(nameof(OfficeEmployee), Schema = "Administration.Offices")]
    public class OfficeEmployee : BaseUserTable
    {

        [DisplayName("Office Name")]
        public Guid OfficeId { get; set; } = default!;
        public Office Office { get; set; } = default!;

    }
}