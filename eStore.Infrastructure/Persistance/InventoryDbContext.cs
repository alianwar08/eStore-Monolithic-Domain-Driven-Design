using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using eStore.Infrastructure.Persistance.Repositories;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace eStore.Infrastructure.Persistance
{
    public class InventoryDbContext  : DbContext
    {
        public string DbPath { get; }

        public InventoryDbContext() : base()
        {

            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

           //// var folder = AppDomain.CurrentDomain.BaseDirectory;//  Environment.SpecialFolder.LocalApplicationData;
           //var path = folder;//Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "InventoryDb.db");

            Database.EnsureCreated();

        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
       
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = @"data source = Localhost\MSSQLSERVER2; initial catalog = InventoryDb; persist security info = True; user id = sa; password = pass1!; multipleactiveresultsets = True;TrustServerCertificate=True; application name =$Application_Name$";
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Product>        Products { get; set; } = null!;
        public DbSet<Cart>           Carts { get; set; } = null!;
        public DbSet<CartProduct>    CartProducts { get; set; } = null!;
        public DbSet<Customer>       Customers { get; set; } = null!;
        public DbSet<Invoice>        Invoices { get; set; } = null!;
        public DbSet<InvoiceItem>    InvoiceItems { get; set; } = null!;

    }

}
