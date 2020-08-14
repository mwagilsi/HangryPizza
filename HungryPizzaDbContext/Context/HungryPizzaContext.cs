using HungryPizza.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizzaDB
{
    public class HungryPizzaContext:DbContext
    {
        public HungryPizzaContext()
        {
        }

        public HungryPizzaContext(DbContextOptions<HungryPizzaContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDelivery> OrderDeliveries { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemSplit> OrderItemSplits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //***************************************
            // Clientes
            //***************************************
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "João", LastName = "Silva", UserName = "joao", Password = "123", ZipCode = "13339-575", Address1 = "Rua Massaharo Kanesaki", Address2 = "Apto 23 Bloco 2", Number = "260", District = "Jardim Sevilha", City = "Indaiatuba", State = "São Paulo", Country = "Brasil" },
                new Customer { Id = 2, FirstName = "José", LastName = "Oliveira", UserName = "jose", Password = "321", ZipCode = "13345-686", Address1 = "Rua João Batista Ferrari", Number = "122", District = "Jardim Bom Princípio", City = "Indaiatuba", State = "São Paulo", Country = "Brasil" }
           );
          

            //***************************************
            // Pizza
            //***************************************
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Flavor = "3 Queijos", Price = 50 },
                new Pizza { Id = 2, Flavor = "Frango com requeijão", Price = 59.99 },
                new Pizza { Id = 3, Flavor = "Mussarela", Price = 42.50 },
                new Pizza { Id = 4, Flavor = "Calabresa", Price = 42.50 },
                new Pizza { Id = 5, Flavor = "Pepperoni", Price = 55 },
                new Pizza { Id = 6, Flavor = "Portuguesa", Price = 45 },
                new Pizza { Id = 7, Flavor = "Veggie", Price = 59.99 }
           );

        
            //***************************************
            // Pedido 
            //***************************************
            modelBuilder.Entity<Order>().HasData(
              new Order { Id = 1, CustomerId = 1, Date = new DateTime(2020, 8, 13, 2, 59, 6, 772, DateTimeKind.Local).AddTicks(9595), Total = 50.00 },
              new Order { Id = 2, CustomerId = 2, Date = new DateTime(2020, 8, 14, 2, 59, 6, 774, DateTimeKind.Local).AddTicks(7060), Total = 55.00 }
            );
          

            //***************************************
            // Entrega 
            //***************************************
            modelBuilder.Entity<OrderDelivery>().HasData(
                new OrderDelivery { Id = 1, Address1 = "Rua Massaharo Kanesaki", Address2 = "Apartamento 23 Bloco 2", City = "Indaiatuba", Country = "Brasil", District = "Jardim Sevilha", Number = "260", OrderId = 1, State = "São Paulo", ZipCode = "13339-575" },
                new OrderDelivery { Id = 2, Address1 = "Mário de Almeida", City = "Indaiatuba", Country = "Brasil", District = "Vila Brizolla", Number = "295", OrderId = 2, State = "São Paulo", ZipCode = "13343-510" }
            );

            //***************************************
            // Itens 
            //***************************************
            modelBuilder.Entity<OrderItem>().HasData(
                 new OrderItem { Id = 1, OrderId = 1, Quantity = 1, SplitPie = true, Total = 50.00 },
                 new OrderItem { Id = 2, OrderId = 2, Quantity = 1, SplitPie = false, Total = 55.00 }
            );

            //***************************************
            // Composição do item 
            //***************************************
            modelBuilder.Entity<OrderItemSplit>().HasData(
                  new OrderItemSplit { Id = 1, OrderItemId = 1, PizzaId = 5, Price = 27.50 },
                  new OrderItemSplit { Id = 2, OrderItemId = 1, PizzaId = 6, Price = 22.50 },
                  new OrderItemSplit { Id = 3, OrderItemId = 2, PizzaId = 5, Price = 55.00 }
            );

        }
    }
}
