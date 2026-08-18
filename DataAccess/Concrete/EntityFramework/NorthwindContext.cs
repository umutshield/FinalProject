using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //bu class'ı oluşturma nedenimiz: veritabanı tabloları ile kendi classlarımızı bağlamak(Context)

    public class NorthwindContext:DbContext
    {
        //veritabanı erişme
        //override on metodu projenin hangi veritabanıyla ilgili olduğunu gösterir
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");    
            //gerçek hayatta Server'a bir ip adresi girilir

        }

        //veritabanı tabloları ile classları eşleştirme
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
