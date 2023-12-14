using Digital.Diary.Models.EntityModels.Administration.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Administration.Associations
{
    public class AssociationVm
    {
        public Guid? Id { get; set; } 
        public string AssociationName { get; set; } = default!;


        public Association ToModel()
        {
            return new Association
            {
                AssociationName = AssociationName,
                Id=Id?? Guid.Empty
            };
        }
    }
}
