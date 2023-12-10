namespace Digital.Diary.Models
{
    public class Result
    {
        public Result()
        {
            ErrorMessages = new List<string>();
        }

        public bool IsSucced { get; set; }
        public ICollection<string> ErrorMessages { get; set; }
    }
}