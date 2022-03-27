﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configurations;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(StockDbContext))]
    partial class StockDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("STOCK_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("STOCKS");
                });

            modelBuilder.Entity("Model.Entities.Trader", b =>
                {
                    b.Property<int>("TraderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TRADER_ID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("LAST_NAME");

                    b.HasKey("TraderId");

                    b.ToTable("TRADERS");
                });

            modelBuilder.Entity("Model.Entities.Trading", b =>
                {
                    b.Property<int>("TraderId")
                        .HasColumnType("int")
                        .HasColumnName("TRADER_ID");

                    b.Property<int>("StockId")
                        .HasColumnType("int")
                        .HasColumnName("STOCK_ID");

                    b.Property<DateTime>("TradedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("TRADED_AT");

                    b.Property<float>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("float")
                        .HasColumnName("PRICE");

                    b.HasKey("TraderId", "StockId", "TradedAt");

                    b.HasIndex("StockId");

                    b.ToTable("TRADER_HAS_STOCKS_JT");
                });

            modelBuilder.Entity("Model.Entities.Trading", b =>
                {
                    b.HasOne("Model.Entities.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Trader", "Trader")
                        .WithMany("Tradings")
                        .HasForeignKey("TraderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");

                    b.Navigation("Trader");
                });

            modelBuilder.Entity("Model.Entities.Trader", b =>
                {
                    b.Navigation("Tradings");
                });
#pragma warning restore 612, 618
        }
    }
}
