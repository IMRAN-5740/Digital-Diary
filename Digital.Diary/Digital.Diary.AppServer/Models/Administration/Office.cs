using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.AppServer.Models.Administration
{
    public class Office
    {
        public Guid Id { get; set; }
        public string OfficeName { get; set; } = default!;
        public int? OfficeLevel { get; set; }
        public string? ImagePath { get; set; }
    }
}