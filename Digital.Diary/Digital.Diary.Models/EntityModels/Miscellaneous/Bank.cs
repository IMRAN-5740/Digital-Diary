using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Miscellaneous
{
    [Table(nameof(Bank), Schema = "Miscellaneous")]
    public class Bank
    {
        public Guid Id { get; set; }
        public string BankName { get; set; } = default!;
        public string BranchName { get; set; } = default!;
        public string Email { get; set; } = default!;

        public string WebAddress { get; set; } = default!;
        public ICollection<BankEmployee>? BankEmployees { get; set; } = new List<BankEmployee>();
    }
}