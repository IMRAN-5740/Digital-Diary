using Digital.Diary.Models.BaseEntityModel;
using Digital.Diary.Models.EntityModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Administration.Associations
{
    [Table(nameof(AssociationEmployee), Schema = "Administration.Associations")]
    public class AssociationEmployee : BaseUserTable
    {

        [DisplayName("Association Name")]
        public Guid AssociationId { get; set; } = default!; 
        public Association Association { get; set; } = default!;


        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;
        public Designation Designation { get; set; } = default!;

    }
}