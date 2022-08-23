using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrascture.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Weapon>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<Ammunition>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<Customer> ().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<EntryRecord>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<ShootingSpot>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<AmmoOrder>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<Order>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<Assignment>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();


            base.OnModelCreating(modelBuilder);
		}
		public DbSet<Weapon> Weapons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Ammunition> Ammunitions { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<EntryRecord> EntryRecords { get; set; }
        public DbSet<ShootingSpot> ShootingSpots { get; set; }
        public DbSet<AmmoOrder> AmmoOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}
