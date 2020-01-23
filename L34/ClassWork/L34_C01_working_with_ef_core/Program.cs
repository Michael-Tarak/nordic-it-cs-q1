using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace L34_C01_working_with_ef_core
{
	class Program
	{
		static void Main(string[] args)
		{
			//var product = new Product(1, "Notebook", 20_000);
			//var customer = new Customer(1, "Ivan");
			//var order = new Order(1, DateTimeOffset.UtcNow, 0.12m, customer);
			//order.OrderLines.Add(new OrderLine(order, 2, product));

			using var context = new OnlineStoreContext();
			context.Database.EnsureCreated();

            var product = new Product("Notebook", 20_000);
            var customer = new Customer("Ivan", "Ivanov");
            var order = new Order(DateTimeOffset.UtcNow, 0.12m, customer);
            order.OrderLines.Add(new OrderLine(order, 2, product));

            context.Orders.AddRange(order);
            context.SaveChanges();

            var lastOrder = context.Orders
                .OrderBy(order => order.OrderDate)
                .Last();
            Console.WriteLine($"The laster order date is: {lastOrder.OrderDate}");

            var firstOrder = context.Orders.First(order => order.Id == 1);
            Console.WriteLine($"The first order date is: {firstOrder.OrderDate}");

            var customerOrders = context.Orders
                .Where(order => order.Customer.Id == 1)
                .ToList();
            Console.WriteLine($"Count of orders of customer with id 1: {customerOrders.Count}");

            var customers = context.Customers.ToList();
            Console.WriteLine($"The customers count: {customers.Count}");

            var orders = context.Orders
                .Include(_ => _.OrderLines)
                .ThenInclude(line => line.Product)
                .ToList();

            foreach (var item in orders)
            {
                Console.WriteLine(item.TotalSum());
            }
        }
    }
}
