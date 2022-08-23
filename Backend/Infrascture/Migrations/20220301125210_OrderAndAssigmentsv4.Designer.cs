﻿// <auto-generated />
using System;
using Infrascture.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrascture.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220301125210_OrderAndAssigmentsv4")]
    partial class OrderAndAssigmentsv4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Domain.Models.AmmoOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AmmunitionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AmmunitionId");

                    b.HasIndex("OrderId");

                    b.ToTable("AmmoOrders");
                });

            modelBuilder.Entity("Domain.Models.Ammunition", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Caliber")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Ammunitions");
                });

            modelBuilder.Entity("Domain.Models.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AmmunitionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Instuctor")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SpotId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WeaponId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AmmunitionId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId");

                    b.HasIndex("SpotId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("BuldingNumber")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirearmsLicense")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Domain.Models.EntryRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateEntry")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateExit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirearmsLicense")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EntryRecords");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsInstructor")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("SpotId")
                        .HasColumnType("uuid");

                    b.Property<int>("TrainigHours")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SpotId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Models.ShootingSpot", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AmmoOrderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateEntry")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateExit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Distance")
                        .HasColumnType("integer");

                    b.Property<Guid?>("InstructorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WeaponId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AmmoOrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("WeaponId");

                    b.ToTable("ShootingSpots");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.Weapon", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Caliber")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DateOfProduction")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfUse")
                        .HasColumnType("integer");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("OrderWeapon", b =>
                {
                    b.Property<Guid>("OrdersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WeaponsId")
                        .HasColumnType("uuid");

                    b.HasKey("OrdersId", "WeaponsId");

                    b.HasIndex("WeaponsId");

                    b.ToTable("OrderWeapon");
                });

            modelBuilder.Entity("Domain.Models.AmmoOrder", b =>
                {
                    b.HasOne("Domain.Models.Ammunition", "Ammunition")
                        .WithMany()
                        .HasForeignKey("AmmunitionId");

                    b.HasOne("Domain.Models.Order", null)
                        .WithMany("AmmoOrders")
                        .HasForeignKey("OrderId");

                    b.Navigation("Ammunition");
                });

            modelBuilder.Entity("Domain.Models.Assignment", b =>
                {
                    b.HasOne("Domain.Models.Ammunition", "Ammunition")
                        .WithMany()
                        .HasForeignKey("AmmunitionId");

                    b.HasOne("Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Domain.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("Domain.Models.ShootingSpot", "Spot")
                        .WithMany()
                        .HasForeignKey("SpotId");

                    b.HasOne("Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Domain.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("Ammunition");

                    b.Navigation("Customer");

                    b.Navigation("Order");

                    b.Navigation("Spot");

                    b.Navigation("User");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.HasOne("Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Domain.Models.ShootingSpot", "Spot")
                        .WithMany()
                        .HasForeignKey("SpotId");

                    b.Navigation("Customer");

                    b.Navigation("Spot");
                });

            modelBuilder.Entity("Domain.Models.ShootingSpot", b =>
                {
                    b.HasOne("Domain.Models.AmmoOrder", "AmmoOrder")
                        .WithMany()
                        .HasForeignKey("AmmoOrderId");

                    b.HasOne("Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Domain.Models.User", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId");

                    b.HasOne("Domain.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("AmmoOrder");

                    b.Navigation("Customer");

                    b.Navigation("Instructor");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OrderWeapon", b =>
                {
                    b.HasOne("Domain.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Navigation("AmmoOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
