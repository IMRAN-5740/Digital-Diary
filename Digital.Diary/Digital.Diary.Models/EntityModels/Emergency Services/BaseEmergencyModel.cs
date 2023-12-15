namespace Digital.Diary.Models.EntityModels.Emergency_Services
{
    public class BaseEmergencyModel
    {
        public Guid Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNum { get; set; } = default!;
    }
}