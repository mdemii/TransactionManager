﻿using DataAccess.EFCore.Entities;
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
            Configure_Currencies_Table(modelBuilder);

            Configure_TransactionStatuses_Table(modelBuilder);

            Configure_Transactions_Table(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void Configure_Currencies_Table(ModelBuilder modelBuilder)
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

        private void Configure_TransactionStatuses_Table(ModelBuilder modelBuilder)
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

                entity.HasData(

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
                    );
            });
        }

        private void Configure_Transactions_Table(ModelBuilder modelBuilder)
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

                entity.HasOne(e => e.Currency)
                      .WithMany()
                      .HasForeignKey(e => e.CurrencyId)
                      .HasConstraintName("FK_Transactions_Currencies");

                entity.HasOne(e => e.Currency)
                      .WithMany()
                      .HasForeignKey(e => e.CurrencyId)
                      .HasConstraintName("FK_Transactions_TransactionStatuses");

                //TODO has data

            });
        }
    }
}
