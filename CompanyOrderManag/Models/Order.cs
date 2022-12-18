namespace CompanyOrderManag.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public Company Company { get; set; } // One relationship
        public Product Product { get; set; } // One relationship
    }
}
