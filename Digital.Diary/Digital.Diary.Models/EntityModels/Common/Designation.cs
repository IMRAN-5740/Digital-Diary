using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Common
{
    [Table(nameof(Designation), Schema = "CommonEntity")]
    public class Designation
    {
        public Guid Id { get; set; }
        public string DesignationName { get; set; } = default!;
    }
}