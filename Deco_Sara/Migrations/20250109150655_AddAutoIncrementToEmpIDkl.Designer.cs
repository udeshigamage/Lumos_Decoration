﻿// <auto-generated />
using System;
using Deco_Sara.dbcontext__;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deco_Sara.Migrations
{
    [DbContext(typeof(Appdbcontext))]
    [Migration("20250109150655_AddAutoIncrementToEmpIDkl")]
    partial class AddAutoIncrementToEmpIDkl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Deco_Sara.Models.Allowance", b =>
                {
                    b.Property<int>("Allowance_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Allowance_Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("Allowance_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Emp_ID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeEmp_ID")
                        .HasColumnType("int");

                    b.Property<int>("Order_ID")
                        .HasColumnType("int");

                    b.HasKey("Allowance_ID");

                    b.HasIndex("EmployeeEmp_ID");

                    b.ToTable("Allowances");
                });

            modelBuilder.Entity("Deco_Sara.Models.Customer", b =>
                {
                    b.Property<int>("Customer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("contactno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Customer_ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Deco_Sara.Models.Decorationstatus", b =>
                {
                    b.Property<int>("DecorationStatus_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Order_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("lastupdatedby_date_time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("lastupdatedby_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("status_description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DecorationStatus_ID");

                    b.ToTable("Decorationstatuses");
                });

            modelBuilder.Entity("Deco_Sara.Models.Employee", b =>
                {
                    b.Property<int>("Emp_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("emp_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("emp_Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("emp_address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("emp_allowance")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("emp_contact_no")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Emp_ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Deco_Sara.Models.Notification", b =>
                {
                    b.Property<int>("Notification_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<string>("actortype")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Notification_ID");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("Deco_Sara.Models.Order", b =>
                {
                    b.Property<int>("Order_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Customer_ID")
                        .HasColumnType("int");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("order_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Order_ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Deco_Sara.Models.Payment", b =>
                {
                    b.Property<int>("Payment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Order_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("payment_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("payment_method")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Payment_ID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Deco_Sara.Models.Role", b =>
                {
                    b.Property<int>("Roll_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Roll_Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Roll_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Roll_ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Deco_Sara.Models.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("RoleRoll_ID")
                        .HasColumnType("int");

                    b.Property<int>("Role_ID")
                        .HasColumnType("int");

                    b.HasKey("User_ID");

                    b.HasIndex("RoleRoll_ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Deco_Sara.Models.Allowance", b =>
                {
                    b.HasOne("Deco_Sara.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeEmp_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Deco_Sara.Models.User", b =>
                {
                    b.HasOne("Deco_Sara.Models.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleRoll_ID");
                });

            modelBuilder.Entity("Deco_Sara.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
