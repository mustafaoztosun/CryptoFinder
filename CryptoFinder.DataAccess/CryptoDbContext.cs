using CryptoFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace CryptoFinder.DataAccess
{
    public class CryptoDbContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Downloaded entity framework sql for connection to database
            //Database creation process integration provided
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = CryptoDb;");
        }

        //Referenced from CryptoFinder.Entities Layer.
        public DbSet<Crypto> Cryptos { get; set; }

    }
}
