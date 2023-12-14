using Digital.Diary.Models.EntityModels.Administration.Committees;

namespace Digital.Diary.Models.ViewModels.Administration.Committees
{
    public class CommitteeVm
    {
        public Guid? Id { get; set; }
        public string CommitteeName { get; set; } = default!;

        public Committee ToModel()
        {
            return new Committee
            {
                CommitteeName = CommitteeName,
                Id = Id ?? Guid.Empty
            };
        }
    }
}