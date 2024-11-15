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

            var categories = dbContext.Categories.ToList();
            
            var firstProduct = dbContext.Products.FirstOrDefault();

            int productId = 6;
            var product = dbContext.Products.FirstOrDefault(e => e.ProductId == productId);

            int modelYear = 2022;
            var model = dbContext.Products.Where(e=> e.ModelYear == modelYear).ToList();

            int customerId = 1;
            var customer = dbContext.Customers.FirstOrDefault(e=> e.CustomerId == customerId);

            var productsWithBrands = dbContext.Products
                .Include(e => e.Brand)
                .Select(e => new
                {
                    ProductName = e.ProductName,
                    BrandName = e.Brand.BrandName
                })
                .ToList();

            int categoryId = 1;
            int productCount = dbContext.Products.Count(e=> e.CategoryId == categoryId);

            int categoryId1 = 1;
            decimal totalListPrice = dbContext.Products
                .Where(e => e.CategoryId == categoryId1)
                .Sum(e => e.ListPrice);

            var avgListPrice = dbContext.Products.Average(p=> p.ListPrice);

            var completedOrders = dbContext.Orders.Where(e => e.OrderStatus == 4).ToList();

            foreach (var category in categories)
            {
                Console.WriteLine($"Category ID: {category.CategoryId}, Name: {category.CategoryName}");
            }
            Console.WriteLine("####################################");
            
            if (firstProduct != null)
            {
                Console.WriteLine($"Product ID: {firstProduct.ProductId}, Name: {firstProduct.ProductName}, Model Year: {firstProduct.ModelYear}");
            }
            Console.WriteLine("####################################");
            
            if (product != null)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Model Year: {product.ModelYear}");
            }
            Console.WriteLine("####################################");
            
            foreach (var product1 in model)
            {
                Console.WriteLine($"Product ID: {product1.ProductId}, Name: {product1.ProductName}, Model Year: {product1.ModelYear}");
            }
            Console.WriteLine("####################################");
            
            if (customer != null)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}");
            }
            Console.WriteLine("####################################");
            
            foreach (var item in productsWithBrands)
            {
                Console.WriteLine($"Product: {item.ProductName}, Brand: {item.BrandName}");
            }
            Console.WriteLine("####################################");

            Console.WriteLine($"Number of products in category {categoryId}: {productCount}");
            Console.WriteLine("####################################");

            Console.WriteLine($"Total List Price for category {categoryId1}: {totalListPrice}");
            Console.WriteLine("####################################");

            Console.WriteLine($"Average List Price of Products: {avgListPrice}");
            Console.WriteLine("####################################");


            foreach (var order in completedOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Status: {order.OrderStatus}");
            }
        }
    }
}
