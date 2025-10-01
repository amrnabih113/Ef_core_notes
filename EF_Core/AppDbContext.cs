using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core
{
    internal class AppDbContext : DbContext
    {
        // represents a table in the database
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var constr = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);

        }

        // the dataset name must be the same as the table name in the database 
        // and the class properties must be the same as the table columns
        // otherwise you need to use data annotations or fluent API to map them
        public DbSet<Employee> Employee { get; set; }
    }
}
