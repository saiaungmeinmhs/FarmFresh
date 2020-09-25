using System.Linq;
using FarmFresh.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmFresh.Context
{
     public partial class FarmFreshContext : DbContext
    {
        public FarmFreshContext()
        {
        }

        public FarmFreshContext(DbContextOptions<FarmFreshContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Unit> Unit { get; set; }

        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Product> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            } 
            
            base.OnModelCreating(modelBuilder);
        }
    }
}