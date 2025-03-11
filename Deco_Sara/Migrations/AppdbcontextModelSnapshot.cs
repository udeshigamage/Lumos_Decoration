﻿// <auto-generated />
using System;
using Deco_Sara.dbcontext__;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deco_Sara.Migrations
{
    [DbContext(typeof(Appdbcontext))]
    partial class AppdbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Deco_Sara.Models.Category", b =>
                {
                    b.Property<int>("Category_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category_description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Category_image")
                        .HasColumnType("longtext");

                    b.Property<string>("Category_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Category_Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Deco_Sara.Models.Customer", b =>
                {
                    b.Property<int>("Customer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Customer_address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Customer_contact_no")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Customer_email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Customer_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
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

                    b.Property<int>("Role_ID")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("emp_Name")
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

                    b.Property<string>("emp_image")
                        .HasColumnType("longtext");

                    b.Property<string>("nic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Emp_ID");

                    b.HasIndex("Role_ID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Deco_Sara.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Customer_ID")
                        .HasColumnType("int");

                    b.Property<string>("FeedbackCategory")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FeedbackDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.ToTable("Feedbacks");
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

                    b.Property<decimal>("Order_allowance")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("Order_allowance_status")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Order_date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Order_deadlinedate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Order_description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Order_payment_status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Order_status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Order_ID");

                    b.HasIndex("Customer_ID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Deco_Sara.Models.Orderitem", b =>
                {
                    b.Property<int>("Orderitem_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Order_ID")
                        .HasColumnType("int");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Orderitem_Id");

                    b.HasIndex("Order_ID");

                    b.HasIndex("Product_ID");

                    b.ToTable("OrderItems");
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

            modelBuilder.Entity("Deco_Sara.Models.Product", b =>
                {
                    b.Property<int>("Product_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Product_discount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Product_image")
                        .HasColumnType("longtext");

                    b.Property<string>("Product_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Product_price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Subcategory_Id")
                        .HasColumnType("int");

                    b.HasKey("Product_Id");

                    b.HasIndex("Category_Id");

                    b.HasIndex("Subcategory_Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Deco_Sara.Models.Role", b =>
                {
                    b.Property<int>("Role_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Role_ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Deco_Sara.Models.Subcategory", b =>
                {
                    b.Property<int>("Subcategory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Subcategory_description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subcategory_image")
                        .HasColumnType("longtext");

                    b.Property<string>("Subcategory_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Subcategory_Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("Subcategories");
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

                    b.Property<int>("Role_ID")
                        .HasColumnType("int");

                    b.HasKey("User_ID");

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

            modelBuilder.Entity("Deco_Sara.Models.Employee", b =>
                {
                    b.HasOne("Deco_Sara.Models.Role", "role")
                        .WithMany()
                        .HasForeignKey("Role_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("Deco_Sara.Models.Order", b =>
                {
                    b.HasOne("Deco_Sara.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Deco_Sara.Models.Orderitem", b =>
                {
                    b.HasOne("Deco_Sara.Models.Order", "Order")
                        .WithMany("Orderitems")
                        .HasForeignKey("Order_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deco_Sara.Models.Product", "Product")
                        .WithMany("Orderitems")
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Deco_Sara.Models.Product", b =>
                {
                    b.HasOne("Deco_Sara.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deco_Sara.Models.Subcategory", "Subcategory")
                        .WithMany()
                        .HasForeignKey("Subcategory_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Deco_Sara.Models.Subcategory", b =>
                {
                    b.HasOne("Deco_Sara.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Deco_Sara.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Deco_Sara.Models.Order", b =>
                {
                    b.Navigation("Orderitems");
                });

            modelBuilder.Entity("Deco_Sara.Models.Product", b =>
                {
                    b.Navigation("Orderitems");
                });
#pragma warning restore 612, 618
        }
    }
}
