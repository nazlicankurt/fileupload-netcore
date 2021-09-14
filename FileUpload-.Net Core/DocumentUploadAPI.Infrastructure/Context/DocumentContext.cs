using DocumentUploadAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentUploadAPI.Infrastructure.Context
{
    public class DocumentContext : DbContext
    {
        public DocumentContext()
        {  }
        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options)
        {

        }

        public DbSet<Document> Documents { get; set; }

        #region Config

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasKey(x => x.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("MSSQL_URI"));
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

    }
}

