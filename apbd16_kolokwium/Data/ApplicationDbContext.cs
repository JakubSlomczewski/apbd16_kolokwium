using System;
using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> o) : base(o) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WashingMachine> WashingMachines { get; set; }
        public DbSet<ExampleTest2.Models.Program> Programs { get; set; }
        public DbSet<WashingMachineProgram> WashingMachinePrograms { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<WashingMachineProgram>()
                .HasKey(x => new { x.WashingMachineId, x.ProgramId });

            b.Entity<WashingMachineProgram>()
                .HasOne(x => x.WashingMachine)
                .WithMany(x => x.WashingMachinePrograms)
                .HasForeignKey(x => x.WashingMachineId);

            b.Entity<WashingMachineProgram>()
                .HasOne(x => x.Program)
                .WithMany(x => x.WashingMachinePrograms)
                .HasForeignKey(x => x.ProgramId);

            b.Entity<Purchase>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.CustomerId);

            b.Entity<Purchase>()
                .HasOne(x => x.WashingMachine)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.WashingMachineId);

            b.Entity<Purchase>()
                .HasOne(x => x.Program)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.ProgramId);

            b.Entity<ExampleTest2.Models.Program>().HasData(
                new ExampleTest2.Models.Program { Id = 1, Name = "Quick Wash", Duration = 69 },
                new ExampleTest2.Models.Program { Id = 2, Name = "Cotton Cycle", Duration = 143 }
            );
            b.Entity<WashingMachine>().HasData(
                new WashingMachine { Id = 1, SerialNumber = "WM2012/S431/12", MaxWeight = 32.23 },
                new WashingMachine { Id = 2, SerialNumber = "WM2014/S491/28", MaxWeight = 52.23 }
            );
            b.Entity<WashingMachineProgram>().HasData(
                new WashingMachineProgram { WashingMachineId = 1, ProgramId = 1, Price = 33.4 },
                new WashingMachineProgram { WashingMachineId = 2, ProgramId = 2, Price = 48.7 }
            );
            b.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = null }
            );
            b.Entity<Purchase>().HasData(
                new Purchase { Id = 1, CustomerId = 1, WashingMachineId = 1, ProgramId = 1, Date = new DateTime(2025, 6, 3, 9, 0, 0), Rating = 4, Price = 33.4 },
                new Purchase { Id = 2, CustomerId = 1, WashingMachineId = 2, ProgramId = 2, Date = new DateTime(2025, 6, 4, 9, 0, 0), Rating = null, Price = 48.7 }
            );
        }
    }
}
