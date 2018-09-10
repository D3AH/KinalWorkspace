using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Producto //Model data
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
    // This class generate the database, this feature is called "FirstCode" a part of EntityFramework

    class ProductoDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
    }
}