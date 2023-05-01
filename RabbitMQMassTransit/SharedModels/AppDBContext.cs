using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class AppDBContext : DbContext
    {

        public AppDBContext()
        {

        }
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }

        public DbSet<Product> products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=ROHIT36A\\SQLEXPRESS; initial catalog=CQRS10AM;persist security info=True;user id=project1;password=Welcome@2023;");
            }

            base.OnConfiguring(optionsBuilder);
        }

    }
}
