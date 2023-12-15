using Digital.Diary.Models.EntityModels.Common;
using Digital.Diary.Models.EntityModels.Miscellaneous;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Miscellaneous
{
    public class BankEmployeeVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;

        public string? ProfileImage { get; set; }
        public Guid BankId { get; set; }
        public string? BankName { get; set; }
        public Guid DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public BankEmployee ToModel()
        {
            return new BankEmployee
            {
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                ProfileImage = ProfileImage,
                BankId = BankId,
                DesignationId = DesignationId,
                Id = Id ?? Guid.Empty
            };
        }
    }
}