using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Student_Activities.Clubs
{
    [Table(nameof(Club), Schema = "StudentActivities.Clubs")]
    public class Club
    {
        public Guid Id { get; set; } = default!;
        public string ClubName { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<ClubEmployee>? ClubEmployees { get; set; } = new List<ClubEmployee>();
    }
}