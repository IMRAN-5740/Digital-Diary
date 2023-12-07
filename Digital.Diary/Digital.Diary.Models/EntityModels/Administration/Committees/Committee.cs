using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Administration.Committees
{
    [Table(nameof(Committee), Schema = "Administration.Committees")]
    public class Committee
    {
        public Guid Id { get; set; } = default!;
        public string CommitteeName { get; set; } = default!;
        public ICollection<CommitteeEmployee>? CommitteeEmployees { get; set; } = new List<CommitteeEmployee>();
    }
}