using Digital.Diary.Models.EntityModels.Administration.Offices;
using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Models.EntityModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Administration.Transportations
{
    public class TransportEmployeeVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string? ProfileImage { get; set; }
        public Guid TransportId { get; set; }
        public string? TransportName { get; set; }
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public TransportEmployee ToModel()
        {
            return new TransportEmployee
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                TransportId= TransportId,
                DesignationId = DesignationId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}
