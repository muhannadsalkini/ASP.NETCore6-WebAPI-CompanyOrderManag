using CompanyOrderManag.Models;

namespace CompanyOrderManag.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
