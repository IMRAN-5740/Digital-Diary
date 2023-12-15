using Digital.Diary.Models.EntityModels.Emergency_Services;

namespace Digital.Diary.Models.ViewModels.Emergency_Services
{
    public class JournalistVm
    {
        public Guid? Id { get; set; }
        public string JournalName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;

        public Journalist ToModel()
        {
            return new Journalist
            {
                JournalName = JournalName,
                Email = Email,
                PhoneNum = PhoneNum,
                Id = Id ?? Guid.Empty
            };
        }
    }
}