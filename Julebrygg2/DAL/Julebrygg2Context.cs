using Julebrygg2.Models;
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

            //Database.SetInitializer(new CircularReferenceDataInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }

        public System.Data.Entity.DbSet<Julebrygg2.Models.Drikke> Drikke { get; set; }
        public System.Data.Entity.DbSet<Julebrygg2.Models.Bruker> Bruker { get; set; }
        public System.Data.Entity.DbSet<Julebrygg2.Models.Rating> Rating { get; set; }

        public override int SaveChanges()
        {
            foreach (var auditableEntity in ChangeTracker.Entries<BaseEntity>())
            {
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {
                    // implementation may change based on the useage scenario, this
                    // sample is for forma authentication.
                    string currentUser = HttpContext.Current.User.Identity.Name;

                    // modify updated date and updated by column for 
                    // adds of updates.
                    auditableEntity.Entity.ModifiedDate = DateTime.Now;
                    // pupulate created date and created by columns for
                    // newly added record.
                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreateDate = DateTime.Now;
                    }
                    else
                    {
                        // we also want to make sure that code is not inadvertly
                        // modifying created date and created by columns 
                        auditableEntity.Property(p => p.CreateDate).IsModified = false;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
