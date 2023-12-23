using Digital.Diary.Models.EntityModels.Academic;

namespace Digital.Diary.Models.ViewModels.Academic
{
    public class FacultyVm
    {
        public Guid? Id { get; set; }
        public string FacultyName { get; set; } = default!;
        public string ShortName { get; set; } = default!;

        public Faculty ToModel()
        {
            return new Faculty
            {
                FacultyName = FacultyName,
                ShortName = ShortName,
                Id = Id ?? Guid.Empty
            };
        }
    }
}