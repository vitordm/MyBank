﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBank.Infra.Data;

namespace MyBank.Infra.Data.Migrations
{
    [DbContext(typeof(MyBankDbContext))]
    [Migration("20200309224833_Migration_2")]
    partial class Migration_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyBank.Domain.Entities.Bank.BankAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("AuthorizationPass")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("BankCustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Digit")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsMainAccount")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Profitable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<decimal>("TotalBalance")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("Uid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BankCustomerId");

                    b.ToTable("BankAccount");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Account = "0010",
                            AuthorizationPass = "1234",
                            BankCustomerId = 1L,
                            Branch = "0001",
                            CreateDate = new DateTime(2020, 3, 9, 19, 48, 32, 817, DateTimeKind.Local).AddTicks(4025),
                            Digit = "1",
                            IsMainAccount = true,
                            Profitable = true,
                            TotalBalance = 0m,
                            Type = "CURRENT_ACCOUNT",
                            Uid = new Guid("ad2fc66e-eecd-42d3-b661-42cab2444320")
                        });
                });

            modelBuilder.Entity("MyBank.Domain.Entities.Bank.BankCustomer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("BankCustomer");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "The North",
                            Document = "00000000000",
                            FullName = "Snow",
                            Name = "John"
                        });
                });

            modelBuilder.Entity("MyBank.Domain.Entities.Bank.BankTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<long>("BankAccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("BankTransaction");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Amount = 0m,
                            BankAccountId = 1L,
                            CreateDate = new DateTime(2020, 3, 9, 19, 48, 32, 830, DateTimeKind.Local).AddTicks(4694),
                            Description = "Initital Transaction"
                        });
                });

            modelBuilder.Entity("MyBank.Domain.Entities.Bank.BankAccount", b =>
                {
                    b.HasOne("MyBank.Domain.Entities.Bank.BankCustomer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("BankCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBank.Domain.Entities.Bank.BankTransaction", b =>
                {
                    b.HasOne("MyBank.Domain.Entities.Bank.BankAccount", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
