using Digital.Diary.Models.BaseEntityModel;
using Digital.Diary.Models.EntityModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Miscellaneous
{
    [Table(nameof(BankEmployee), Schema = "Miscellaneous")]
    public class BankEmployee : BaseUserTable
    {
        [DisplayName("Bank Name")]
        public Guid BankId { get; set; } = default!;

        public Bank Bank { get; set; } = default!;

        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;
        public Designation Designation { get; set; } = default!;
    }
}