using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Julebrygg2.DAL
{
    public class Julebrygg2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Julebrygg2Context() : base("name=Julebrygg2Context")
        {
        }

        public System.Data.Entity.DbSet<Julebrygg2.Models.Drikke> Drikke { get; set; }
        public System.Data.Entity.DbSet<Julebrygg2.Models.Bruker> Bruker { get; set; }
        public System.Data.Entity.DbSet<Julebrygg2.Models.Rating> Rating { get; set; }
    }
}
