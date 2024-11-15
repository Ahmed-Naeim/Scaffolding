using BikeStores.Data;
using BikeStores.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            var orders = dbContext.Orders.Include(e=> e.Staff).ThenInclude(e=>e.Store).ToList();

            foreach (var item in orders) {
                
            }
        }
    }
}
