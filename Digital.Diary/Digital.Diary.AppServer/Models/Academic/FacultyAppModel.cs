using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Digital.Diary.AppServer.Models.Academic
{
    public class FacultyAppModel
    {
        public string Id { get; set; }
        public string FacultyName { get; set; } = default!;
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = default!;
    }
}