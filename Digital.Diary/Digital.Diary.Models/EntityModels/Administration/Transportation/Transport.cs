using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Administration.Transportation
{
    [Table(nameof(Transport), Schema = "Administration.Transportation")]
    public class Transport
    {
        public Guid Id { get; set; }
        public string BusName { get; set; } = default!;

        public string StartingPoint { get; set; } = default!;
        public string EndingPoint { get; set; } = default!;

        public ICollection<TransportEmployee>? TransportEmployees { get; set; } = new List<TransportEmployee>();
    }
}