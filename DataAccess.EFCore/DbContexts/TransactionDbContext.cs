using DataAccess.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            var currencyEntityList = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                                .Select(ci => ci.LCID).Distinct()
                                                .Select(id => new RegionInfo(id))
                                                .GroupBy(r => r.ISOCurrencySymbol)
                                                .Select(g => g.First())
                                                .Select((regionInfo, index) =>
                                                    new CurrencyEntity
                                                    {
                                                        Id = (sbyte)(index + 1),
                                                        Name = regionInfo.EnglishName,
                                                        Code = regionInfo.ISOCurrencySymbol,
                                                        Symbol = regionInfo.CurrencySymbol
                                                    })
                                                .ToList();


            var statuses = new List<TransactionStatusEntity>
            {
                        new TransactionStatusEntity
                        {
                            Id = 1,
                            Name = "Approved",
                            ShortName = "A",
                        },

                        new TransactionStatusEntity
                        {
                            Id = 2,
                            Name = "Rejected",
                            ShortName = "R",
                        },

                        new TransactionStatusEntity
                        {
                            Id = 3,
                            Name = "Done",
                            ShortName = "D",
                        }
            };


            Configure_Currencies_Table(modelBuilder, currencyEntityList);

            Configure_TransactionStatuses_Table(modelBuilder, statuses);

            Configure_Transactions_Table(modelBuilder, currencyEntityList, statuses);

            base.OnModelCreating(modelBuilder);
        }

        private void Configure_Currencies_Table(ModelBuilder modelBuilder, List<CurrencyEntity> currencyEntityList)
        {
            modelBuilder.Entity<CurrencyEntity>(entity =>
            {
                entity.ToTable("Currencies");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("CurrencyId")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasData(currencyEntityList);

            });
        }

        private void Configure_TransactionStatuses_Table(ModelBuilder modelBuilder, List<TransactionStatusEntity> statuses)
        {
            modelBuilder.Entity<TransactionStatusEntity>(entity =>
            {
                entity.ToTable("TransactionStatuses");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("TransactionStatusId")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.HasData(statuses);
            });
        }

        private void Configure_Transactions_Table(ModelBuilder modelBuilder, List<CurrencyEntity> currencyEntityList, List<TransactionStatusEntity> statuses)
        {
            modelBuilder.Entity<TransactionEntity>(entity =>
            {
                entity.ToTable("Transactions");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("TransactionId")
                    .IsRequired()
                    .HasMaxLength(30)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .IsRequired();

                entity.Property(e => e.TransactionDate)
                    .IsRequired();

                entity.HasOne(e => e.Currency)
                      .WithMany()
                      .HasForeignKey(e => e.CurrencyId)
                      .HasConstraintName("FK_Transactions_Currencies");

                entity.HasOne(e => e.Currency)
                      .WithMany()
                      .HasForeignKey(e => e.CurrencyId)
                      .HasConstraintName("FK_Transactions_TransactionStatuses");

                var transactionList = new List<TransactionEntity>();

                for(var index = 1; index < 100; index++)
                {
                    var transaction = new TransactionEntity
                    {
                        Id = $"Invoice000000{index}",
                        Amount = index * 10,
                        TransactionDate = new DateTime(2020,index % 12 + 1, index % 20 + 1, index % 12 + 1, 0, 0),
                        CurrencyId = (sbyte)(index % 10),
                        TransactionStatusId = (sbyte)(index % 3 + 1),
                    };

                    transactionList.Add(transaction);
                }

                entity.HasData(transactionList);

            });
        }
    }
}
