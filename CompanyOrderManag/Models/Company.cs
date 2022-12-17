namespace CompanyOrderManag.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool state { get; set; }
        public TimeSpan PomationStartTime { get; set; }
        public TimeSpan PromationEndTime { get; set; }
        public ICollection<Product> Product { get; set; } // One To Many relationship
        public ICollection<Order> Order { get; set; } // One To Many relationship
    }
}
