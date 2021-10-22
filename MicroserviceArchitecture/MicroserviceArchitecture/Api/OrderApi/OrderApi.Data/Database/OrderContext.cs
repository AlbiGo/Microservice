using Microsoft.EntityFrameworkCore;
using OrderApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Data.Database
{
    public partial class  OrderContext : DbContext
    {
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
       // public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Card> Cards { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
