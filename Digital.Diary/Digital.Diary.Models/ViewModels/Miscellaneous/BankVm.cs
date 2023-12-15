using Digital.Diary.Models.EntityModels.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.ViewModels.Miscellaneous
{
    public class BankVm
    {
        public Guid? Id { get; set; }
        public string BankName { get; set; } = default!;
        public string BranchName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string WebAddress { get; set; } = default!;

        public Bank ToModel()
        {
            return new Bank
            {
                BankName = BankName,
                BranchName = BranchName,
                Email = Email,
                WebAddress = WebAddress,
                Id = Id ?? Guid.Empty
            };
        }
    }
}