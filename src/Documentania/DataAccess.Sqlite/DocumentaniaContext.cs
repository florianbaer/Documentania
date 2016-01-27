using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Sqlite
{
    using DataAccess.Sqlite.Entities;

    using Microsoft.Data.Entity;
    using Microsoft.Data.Sqlite;

    public class DocumentaniaContext : DbContext
    {
        public DocumentaniaContext(): base()
        {

        }


        public DbSet<Tag> Tags { get; set; }
        public DbSet<Document> Documents { get; set; }

        // This method connects the context with the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Documentania.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentTag>()
                .HasKey(t => new { t.DocumentId, t.TagId });

            modelBuilder.Entity<DocumentTag>()
                .HasOne(pt => pt.Document)
                .WithMany(p => p.DocumentTags)
                .HasForeignKey(pt => pt.DocumentId);

            modelBuilder.Entity<DocumentTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.DocumentTags)
                .HasForeignKey(pt => pt.TagId);


            base.OnModelCreating(modelBuilder);
        }
    }
}