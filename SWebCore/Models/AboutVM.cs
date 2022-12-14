namespace SWebCore.Models
{
    public class AboutVM
    {
        public int AboutID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Age { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }

        public int AgeCalculate()
        {
            return (DateTime.Now - Age).Value.Days / 365;
        }
    }
}
