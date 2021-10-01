using System;
using Microsoft.EntityFrameworkCore;
using Ntombizodwa.PetShop.EntityFramework.Entities;

namespace Ntombizodwa.PetShop.EntityFramework
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options)
        {
            
        }

        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<InsuranceEntity> Insurances { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        //public DbSet<PetColorEntity> PetColors { get; set; }
        //public DbSet<ColorEntity> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<PetColorEntity>()
                .HasOne(pc => pc.Pet)
                .WithMany(p => p.Colors);
            
            modelBuilder.Entity<PetColorEntity>()
                .HasOne(pc => pc.Color)
                .WithMany();
                */
            
            
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 1, Name = "SaveStuff", Price = 22});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 2, Name = "GoodStuff", Price = 50});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 3, Name = "NiceStuff", Price = 400});

            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity
                {
                    Id = 1,
                    Name = "Bo",
                    BirthDate = DateTime.Today,
                    SoldDate = DateTime.Today,
                    Price = 400,
                    Color = "Green",
                    InsuranceId = 1,
                    PetTypeId = 1,
                    OwnerId = 1
                });
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity
                {
                    Id = 2,
                    Name = "Per",
                    BirthDate = DateTime.Today,
                    SoldDate = DateTime.Today,
                    Price = 1000,
                    Color = "Blue",
                    InsuranceId = 2,
                    PetTypeId = 2,
                    OwnerId = 2
                });
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity
                {
                    Id = 3,
                    Name = "Frank",
                    BirthDate = DateTime.Today,
                    SoldDate = DateTime.Today,
                    Price = 200,
                    Color = "Yellow",
                    InsuranceId = 3,
                    PetTypeId = 3,
                    OwnerId = 3
                });
            
            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity
            {
                Id = 1,
                Name = "Dog"
            });
            
            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity
            {
                Id = 2,
                Name = "Cat"
            });
            
            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity
            {
                Id = 3,
                Name = "Goat"
            });
            
            modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity
            {
                Id = 1,
                Name = "Joe"
            });
            
            modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity
            {
                Id = 2,
                Name = "Kanye"
            });
            
            modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity
            {
                Id = 3,
                Name = "Mamma"
            });

            /*
            modelBuilder.Entity<PetColorEntity>().HasData(new PetColorEntity
            {
                PetId = 1,
                ColorId = 1
            });
            modelBuilder.Entity<PetColorEntity>().HasData(new PetColorEntity
            {
                PetId = 1,
                ColorId = 3
            });
            */
            
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.PetType).WithMany()
                .HasForeignKey(petEntity => new {petEntity.PetTypeId});
            
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.Insurance).WithMany();
            
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.Owner).WithMany();
        }

        
        
    }
}