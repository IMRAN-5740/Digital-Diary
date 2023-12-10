using Digital.Diary.Models.EntityModels.Academic;

namespace Digital.Diary.Models.ViewModels.Academic
{
    public class FacultyVm
    {
        public Guid? Id { get; set; }
        public string FacultyName { get; set; } = default!;

        public Faculty ToModel()
        {
            return new Faculty
            {
                FacultyName = FacultyName,
                Id = Id ?? Guid.Empty
            };
        }
    }
}