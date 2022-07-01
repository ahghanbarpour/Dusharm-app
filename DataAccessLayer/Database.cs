using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class Database : DbContext
    {
        public Database() : base("Dusharm")
        {

        }

        public DbSet<patient> crud_p { get; set; }
        public DbSet<doctor> crud_d { get; set; }
        
    }
}
