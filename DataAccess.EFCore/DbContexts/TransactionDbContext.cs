using DataAccess.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.DbContexts
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
           : base(options)
        {
        }

        public DbSet<TransactionEntity> Transactions { get; set; }

        public DbSet<CurrencyEntity> Currencies { get; set; }

        public DbSet<TransactionStatusEntity> TransactionStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
