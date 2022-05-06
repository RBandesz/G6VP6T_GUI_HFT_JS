// <copyright file="TireShopLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TireShop.Data;
    using TireShop.Data.Tables;
    using TireShop.Repository;
    using TireShop.Repository.BrandRepo;
    using TireShop.Repository.TireRepo;
    using TireShop.Repository.TireSpecificationRepo;

    /// <summary>
    /// TireShopLogic class.
    /// </summary>
    public class TireShopLogic : ITireShopLogic
    {
        private ITireRepository tireRepo;
        private IBrandRepository brandRepo;
        private ITireSpecificationRepository tireSpecificationRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="TireShopLogic"/> class.
        /// </summary>
        /// <param name="tirerepo">tirerepo.</param>
        /// <param name="brandRepo">brand repo.</param>
        /// <param name="tireSpecificationRepo">tire spec repo.</param>
        public TireShopLogic(ITireRepository tirerepo, IBrandRepository brandRepo, ITireSpecificationRepository tireSpecificationRepo)
        {
            this.tireRepo = tirerepo;
            this.brandRepo = brandRepo;
            this.tireSpecificationRepo = tireSpecificationRepo;
        }

        /// <summary>
        /// Gets all the tires.
        /// </summary>
        /// <returns>with all the tires.</returns>
        public IList<Tire> GetAllTires()
        {
            return this.tireRepo.GetAll().ToList();
        }

        /// <summary>
        /// Get all brands.
        /// </summary>
        /// <returns>With all brand.</returns>
        public IList<Brand> GetAllBrands()
        {
            return this.brandRepo.GetAll().ToList();
        }

        /// <summary>
        /// Get all tirespec.
        /// </summary>
        /// <returns>with all tire spec.</returns>
        public IList<TireSpecification> GetAllTireSpecifications()
        {
            return this.tireSpecificationRepo.GetAll().ToList();
        }

        /// <summary>
        /// Gets the tire id.
        /// </summary>
        /// <param name="id">Tire id.</param>
        /// <returns>With th tireid.</returns>
        public Tire GetTireById(int id)
        {
            return this.tireRepo.GetOne(id);
        }

        /// <summary>
        /// Gets the tire id.
        /// </summary>
        /// <param name="id">Tire id.</param>
        /// <returns>With th tireid.</returns>
        public Brand GetBrandById(int id)
        {
            return this.brandRepo.GetOne(id);
        }

        /// <summary>
        /// Gets the tire id.
        /// </summary>
        /// <param name="id">Tire id.</param>
        /// <returns>With th tireid.</returns>
        public TireSpecification GetTireSpecificationById(int id)
        {
            return this.tireSpecificationRepo.GetOne(id);
        }

        /// <summary>
        /// Brand avg prices.
        /// </summary>
        /// <returns>with avg prices.</returns>
        public IList<AvarageResult> BrandAvarages()
        {
            var q = from tire in this.tireRepo.GetAll()
                    group tire by new { tire.Brand.ID, tire.Brand.Name } into grp
                    select new AvarageResult()
                    {
                        BrandName = grp.Key.Name,
                        AvaragePrice = (double)grp.Average(a => a.Price),
                    };
            return q.ToList();
        }

        /// <summary>
        /// Is the place same?.
        /// </summary>
        /// <param name="brandName">brand name.</param>
        /// <param name="tireName">tire name.</param>
        /// <returns>with the names and a bool.</returns>
        public IList<HQMadeofPlace> HQMadeofPlaces(string brandName, string tireName)
        {
            var b = from tire in this.tireRepo.GetAll()
                    where tire.TireName == tireName
                    where tire.Brand.Name == brandName
                    where tire.Brand.ID == tire.BrandID
                    select new HQMadeofPlace { BrandHQ = tire.Brand.CountryName, TireMadePlace = tire.TireSpecification.ProductionCountryName, SamePlace = tire.Brand.CountryName.Equals(tire.TireSpecification.ProductionCountryName) };
            return b.ToList();
        }

        public IList<TirePriceSUM> TirePriceSUMs()
        {
            var q = from tire in this.tireRepo.GetAll()
                    group tire by new { tire.Brand.ID, tire.Brand.Name } into grp
                    select new TirePriceSUM()
                    {
                        BrandName = grp.Key.Name,
                         PriceSum= grp.Sum(a => a.Price),
                    };
            return q.ToList();
        }


        public IList<TireByDiameter> TireByDiameters(int diameter)
        {
            var b = from tire in this.tireRepo.GetAll()
                    where tire.Diameter == diameter
                    select new TireByDiameter { BrandName = tire.Brand.Name,TireName = tire.TireName ,Diameter = tire.Diameter};
            return b.ToList();
        }

        /// <summary>
        /// Gets you a tire with the params.
        /// </summary>
        /// <param name="maxPrice">your budget.</param>
        /// <param name="width">tire's width.</param>
        /// <param name="aspectRatio">tire's aspect ratio.</param>
        /// <param name="diameter">tire's diameter.</param>
        /// <returns>with a tire.</returns>
        public IList<TireRecommendation> TireRecommendations(int maxPrice, int width, int aspectRatio, int diameter)
        {
            var b = from tire in this.tireRepo.GetAll()
                    
                    where tire.Price <= maxPrice
                    where tire.Width == width
                    where tire.AspectRatio == aspectRatio
                    where tire.Diameter == diameter
                    select new TireRecommendation { BrandName = tire.Brand.Name, TireName = tire.TireName, Width = tire.Width, AspectRatio = tire.AspectRatio, Diameter = tire.Diameter, TirePrice = tire.Price };
            return b.ToList();
        }

        /// <summary>
        /// Get the avarages price per brand.
        /// </summary>
        /// <returns>with avg prices.</returns>
        public Task<List<AvarageResult>> BrandAvaragesAsync()
        {
            var t = Task.Run(() => (from tire in this.tireRepo.GetAll()
                group tire by new { tire.Brand.ID, tire.Brand.Name } into grp
                    select new AvarageResult()
                    {
                        BrandName = grp.Key.Name,
                        AvaragePrice = (double)grp.Average(a => a.Price),
                    }).OrderByDescending(x => x.AvaragePrice).ToList());
            return t;
        }

        /// <summary>
        /// See if the hq country same with the production country.
        /// </summary>
        /// <param name="brandName">brand name.</param>
        /// <param name="tireName">tire name.</param>
        /// <returns>brand hq country, tire production country, is the same bool.</returns>
        public Task<List<HQMadeofPlace>> HQMadeofPlacesAsync(string brandName, string tireName)
        {
            var b = Task.Run(() => (from tire in this.tireRepo.GetAll()
                    join brand in this.brandRepo.GetAll() on tire.BrandID equals brand.ID
                    join tireSpecification in this.tireSpecificationRepo.GetAll() on tire.ID equals tireSpecification.TireID
                    where tire.TireName == tireName
                    where brand.Name == brandName
                    where brand.ID == tire.BrandID
                    select new HQMadeofPlace { BrandHQ = brand.CountryName, TireMadePlace = tireSpecification.ProductionCountryName, SamePlace = brand.CountryName.Equals(tireSpecification.ProductionCountryName) }).ToList());
            return b;
        }

        /// <summary>
        /// Picks you a tire you should buy.
        /// </summary>
        /// <param name="maxPrice">your buget.</param>
        /// <param name="width">your tires width.</param>
        /// <param name="aspectRatio">your tires aspectRatio.</param>
        /// <param name="diameter">your tires diameter.</param>
        /// <returns>with the selected tire for you.</returns>
        public Task<List<TireRecommendation>> TireRecommendationsAsync(int maxPrice, int width, int aspectRatio, int diameter)
        {
            var b = Task.Run(() => (from tire in this.tireRepo.GetAll()
                    join brand in this.brandRepo.GetAll() on tire.BrandID equals brand.ID
                    where tire.Price <= maxPrice
                    where tire.Width == width
                    where tire.AspectRatio == aspectRatio
                    where tire.Diameter == diameter
                    select new TireRecommendation { BrandName = brand.Name, TireName = tire.TireName, Width = tire.Width, AspectRatio = tire.AspectRatio, Diameter = tire.Diameter, TirePrice = tire.Price }).ToList());
            return b;
        }
    }
}
