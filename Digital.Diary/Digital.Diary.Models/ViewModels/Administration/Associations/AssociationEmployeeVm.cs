using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Models.EntityModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Administration.Associations
{
    public class AssociationEmployeeVm
    {
        public Guid? Id { get; set; } 
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string? ProfileImage { get; set; }
        public Guid AssociationId { get; set; }
        public string? AssociationName { get; set; } 
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; } 

        public AssociationEmployee ToModel()
        {
            return new AssociationEmployee
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                AssociationId=AssociationId,
                DesignationId=DesignationId,
                Id=Id?? Guid.Empty
            };
        }


    }
}
