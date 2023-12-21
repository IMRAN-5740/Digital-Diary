using Digital.Diary.AppServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Digital.Diary.AppServer.Models.Academic
{
    public class Faculty
    {
        public Guid Id { get; set; }
        public string FacultyName { get; set; } = default!;
        public string? ImagePath { get; set; }
    }
}