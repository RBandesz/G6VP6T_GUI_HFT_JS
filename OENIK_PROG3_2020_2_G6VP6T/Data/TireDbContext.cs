// <copyright file="TireDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Data
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using TireShop.Data.Tables;

    /// <summary>
    /// Initializes a new instance of the TireDbContext.
    /// </summary>
    public partial class TireDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TireDbContext"/> class.
        /// </summary>
        public TireDbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets Brands.
        /// </summary>
        public virtual DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Gets or sets tiresizes.
        /// </summary>
        public virtual DbSet<Tire> Tires { get; set; }

        /// <summary>
        /// Gets or sets tirespecification.
        /// </summary>
        public virtual DbSet<TireSpecification> TireSpecification { get; set; }

        /// <summary>
        /// Creating db file.
        /// </summary>
        /// <param name="optionsBuilder">opitonsbuilder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\TireDB.mdf; 
                                Integrated Security=True; MultipleActiveResultSets=true");
            }
        }

        /// <summary>
        /// Creating model.
        /// </summary>
        /// <param name="modelBuilder">modelbuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Tire t0 = new Tire() { ID = 1, BrandID = 1, Price = 16000, Width = 205, AspectRatio = 50, Diameter = 15, TireName = "SportContact 5" };
            Tire t10 = new Tire() { ID = 11, BrandID = 4, Price = 19000, Width = 205, AspectRatio = 50, Diameter = 15, TireName = "Winter icept s2" };
            Tire t6 = new Tire() { ID = 7, BrandID = 1, Price = 20000, Width = 215, AspectRatio = 45, Diameter = 17, TireName = "SportContact 5" };
            Tire t7 = new Tire() { ID = 8, BrandID = 2, Price = 40000, Width = 275, AspectRatio = 35, Diameter = 18, TireName = "Pilot Sport" };
            Tire t8 = new Tire() { ID = 9, BrandID = 4, Price = 36000, Width = 250, AspectRatio = 40, Diameter = 18, TireName = "Ventus 3" };
            Tire t9 = new Tire() { ID = 10, BrandID = 6, Price = 24000, Width = 200, AspectRatio = 45, Diameter = 16, TireName = "ultragrip 9" };
            Tire t1 = new Tire() { ID = 2, BrandID = 2, Price = 18000, Width = 215, AspectRatio = 50, Diameter = 15, TireName = "PilotSport" };
            Tire t2 = new Tire() { ID = 3, BrandID = 3, Price = 20000, Width = 220, AspectRatio = 65, Diameter = 17, TireName = "PZero" };
            Tire t3 = new Tire() { ID = 4, BrandID = 4, Price = 25000, Width = 220, AspectRatio = 50, Diameter = 17, TireName = "Ventus S12" };
            Tire t4 = new Tire() { ID = 5, BrandID = 5, Price = 30000, Width = 220, AspectRatio = 40, Diameter = 18, TireName = "ADVAN" };
            Tire t5 = new Tire() { ID = 6, BrandID = 1, Price = 15000, Width = 205, AspectRatio = 50, Diameter = 16, TireName = "SportContact 4" };
            Brand b0 = new Brand() { ID = 1, Name = "Continental", CEOName = "Elmar Degenhart", Factories = 5, Headquarter = "Hanover", CountryName = "Germany",  };
            Brand b1 = new Brand() { ID = 2, Name = "Michelin", CEOName = "Florent Menegaux", Factories = 4, Headquarter = "	Clermont-Ferrand", CountryName = "France", };
            Brand b2 = new Brand() { ID = 3, Name = "Pirelli", CEOName = "Alberto Pirelli", Factories = 10, Headquarter = "Milano", CountryName = "Italy", };
            Brand b3 = new Brand() { ID = 4, Name = "Hankook", CEOName = "Cho Hong Jai", Factories = 20, Headquarter = "Seoul", CountryName = "South Korea", };
            Brand b4 = new Brand() { ID = 5, Name = "Yokohama", CEOName = "Fumiko Hayashi", Factories = 3, Headquarter = "Tokyo", CountryName = "Japan", };
            Brand b5 = new Brand() { ID = 6, Name = "Goodyear", CEOName = "	Richard J. Kramer", Factories = 10, Headquarter = "Akron", CountryName = "USA", };
            TireSpecification s0 = new TireSpecification() { ID = 1, TireID = 1, DOTNumber = 3020, ProductionCountryName = "Romania", ProductionWeek = 30, ProductionYear = 2020, LoadIndex = 85, SpeedRating = "T" };
            TireSpecification s1 = new TireSpecification() { ID = 2, TireID = 2, DOTNumber = 3720, ProductionCountryName = "France", ProductionWeek = 37, ProductionYear = 2020, LoadIndex = 86, SpeedRating = "V" };
            TireSpecification s2 = new TireSpecification() { ID = 3, TireID = 3, DOTNumber = 4019, ProductionCountryName = "Italy", ProductionWeek = 40, ProductionYear = 2019,  LoadIndex = 71, SpeedRating = "H" };
            TireSpecification s3 = new TireSpecification() { ID = 4, TireID = 4, DOTNumber = 1118, ProductionCountryName = "Hungary", ProductionWeek = 11, ProductionYear = 2018,  LoadIndex = 80, SpeedRating = "H" };
            TireSpecification s4 = new TireSpecification() { ID = 5, TireID = 5, DOTNumber = 1819, ProductionCountryName = "USA", ProductionWeek = 18, ProductionYear = 2019,  LoadIndex = 84, SpeedRating = "ZR" };

            modelBuilder.Entity<Brand>().HasData(b0, b1, b2, b3, b4, b5);
            modelBuilder.Entity<Tire>().HasData(t0, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            modelBuilder.Entity<TireSpecification>().HasData(s0, s1, s2, s3, s4);

            modelBuilder.Entity<Tire>(entity =>
            {
                entity.HasOne(tiresizes => tiresizes.Brand).WithMany(tire => tire.Tires);
            });
            modelBuilder.Entity<TireSpecification>(entity =>
            {
                entity.HasOne(tirespecification => tirespecification.Tire).WithMany(tire => tire.TireSpecifications);
            });
        }
    }
}
