namespace CompanyOrderManag.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool state { get; set; }
        public DateTime PomationStartTime { get; set; }
        public DateTime PromationEndTime { get; set; }
        public ICollection<Product> Products { get; set; } // One To Many relationship
        public ICollection<Order> Orders { get; set; } // One To Many relationship
    }
}
