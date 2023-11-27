using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.BaseEntityModel
{
    public class BaseUserTable
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Email {  get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
        public string? ProfileImage {  get; set; }
    }
}
