using Microsoft.EntityFrameworkCore;
using Tree.Models;

namespace Tree.Context
{
    public class TreeContext : DbContext
    {
        public TreeContext(DbContextOptions<TreeContext> options) : base(options)
        {

        }
        public TreeContext()
        {

        }

       
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<RelAttribute> RelAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelAttribute>()
                .HasOne(r => r.Attribute)
                .WithMany(r => r.Children)
                .HasForeignKey(r => r.FkAttributeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RelAttribute>()
                .HasOne(r => r.AttributeParent)
                .WithMany(r => r.Parents)
                .HasForeignKey(r => r.FkAttributeParentId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
