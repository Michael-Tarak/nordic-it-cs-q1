﻿// <auto-generated />
using System;
using L34_C01_working_with_ef_core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace L34_C01_working_with_ef_core.Migrations
{
    [DbContext(typeof(OnlineStoreContext))]
    [Migration("20200121164932_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("L34_C01_working_with_ef_core.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("L34_C01_working_with_ef_core.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("L34_C01_working_with_ef_core.OrderLine", b =>
                {
                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("L34_C01_working_with_ef_core.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("L34_C01_working_with_ef_core.Order", b =>
                {
                    b.HasOne("L34_C01_working_with_ef_core.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("L34_C01_working_with_ef_core.OrderLine", b =>
                {
                    b.HasOne("L34_C01_working_with_ef_core.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("L34_C01_working_with_ef_core.Product", "Product")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
