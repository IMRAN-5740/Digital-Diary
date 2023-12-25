using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Administration.Offices
{
    [Table(nameof(Office), Schema = "Administration.Offices")]
    public class Office
    {
        public Guid Id { get; set; } = default!;
        public string OfficeName { get; set; } = default!;
        public int OfficeLevel { get; set; }
        public ICollection<OfficeEmployee>? OfficeEmployees { get; set; } = new List<OfficeEmployee>();
    }
}