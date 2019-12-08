using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Models
{
    public class ReSaleDataBaseContext : DbContext
    {

        public DbSet<ReSaleModel> User { get; set; }


        public ReSaleDataBaseContext(DbContextOptions<ReSaleDataBaseContext> options) : base(options)
        {
            Database.Migrate();
        }

    }
}
