using CompanyOrderManag.Data;
using CompanyOrderManag.Models;
using System.Diagnostics.Metrics;

namespace CompanyOrderManag
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        TimeSpan time = new TimeSpan(08, 30, 00);
        TimeSpan time2 = new TimeSpan(20, 00, 00);
        public void SeedDataContext()
        {
            var order = new List<Order>()
                {
                    new Order()
                    {
                        UserName = "Ahmet",
                        OrderDate = DateTime.Now,

                        Product = new Product()
                        {
                            Name = "p1",
                            Stok = 10,
                            Price = 20,
                            Company = new Company()
                            {
                                Name="Teknosa",
                                state = true, 
                                PomationStartTime = DateTime.Today + time,
                                PromationEndTime = DateTime.Today + time2,
                            }
                        },
                        Company = new Company()
                            {
                                Name="Mediamarket",
                                state = true,
                                PomationStartTime = DateTime.Today + time,
                                PromationEndTime = DateTime.Today + time2,
                            }
                    }
                };
            dataContext.Orders.AddRange(order);
            dataContext.SaveChanges();

        }
    }
}