using Digital.Diary.Models.EntityModels.Academic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Administration.Offices
{
    [Table(nameof(Office), Schema = "Administration.Offices")]
    public class Office
    {
        public Guid Id { get; set; } = default!;
        public string OfficeName { get; set; } = default!;
        public ICollection<OfficeEmployee>? OfficeEmployees { get; set; } = new List<OfficeEmployee>();

    }
}