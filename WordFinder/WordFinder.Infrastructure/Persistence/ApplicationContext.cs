using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WordFinder.Domain.Entities;

namespace WordFinder.Infrastructure.Persistence
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Matrix> Matrix { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matrix>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Matrix");

                entity.ToTable("Matrix", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Items)
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasMaxLength(100);


            });
        }
    }
}