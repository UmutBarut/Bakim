namespace Bakim.ViewModels
{
    [Serializable]
    public class CallDtoViewModel
    {
        public int CallId { get; set; }
        public string MachineName { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmergency { get; set; }
        public string? Description { get; set; }
    }


}
