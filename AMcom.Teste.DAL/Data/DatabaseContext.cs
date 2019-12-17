using AMcom.Teste.DAL.Interface.Entity;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMcom.Teste.DAL.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        { }

        public DbSet<Ubs> Ubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\\mssqllocaldb;Database=UbsDatabase;Trusted_Connection=True;ConnectRetryCount=0",
                x => x.UseNetTopologySuite());
        }
    }
}
