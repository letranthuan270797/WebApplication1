using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabasaProvider
{
    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<kymdan_Users> kymdan_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<kymdan_Users>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<kymdan_Users>()
                .Property(e => e.Uid)
                .IsUnicode(false);

            modelBuilder.Entity<kymdan_Users>()
                .Property(e => e.Pwd)
                .IsUnicode(false);
        }
    }
}
