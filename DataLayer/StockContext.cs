using DataLayer.ResponseClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StockContext : DbContext
    {
        public DbSet<BSEScrips> bseScrips { get; set; }

        public DbSet<BSEEqtyMarketWatch> bSEEqtyMarketWatches { get; set; }

        public string path = @"C:\Users\IAmTheWizard\source\repos\Stock_Trading_App_WPF\DataLayer\Database\BSEDatabase.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={path}");

        //"ConnectionStrings": "Conn": "Data Source= DESKTOP-1FM0G44\\SQLSERVEREXP; Database= ECDB; Integrated Security= True; TrustServerCertificate=True;"

    }
}
