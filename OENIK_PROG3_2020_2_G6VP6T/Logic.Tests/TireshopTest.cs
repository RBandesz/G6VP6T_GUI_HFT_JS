// <copyright file="TireshopTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using TireShop.Data;
    using TireShop.Data.Tables;
    using TireShop.Repository.BrandRepo;
    using TireShop.Repository.TireRepo;
    using TireShop.Repository.TireSpecificationRepo;

    /// <summary>
    /// Tireshoptest class.
    /// </summary>
    [TestFixture]
    public class TireshopTest
    {
        private Mock<ITireRepository> mockedTireRepo;
        private Mock<IBrandRepository> mockedBrandRepo;
        private Mock<ITireSpecificationRepository> mockedTireSpecificationRepo;
        private TireShopLogic tireShopLogic;

        /// <summary>
        /// Setup method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.mockedTireRepo = new Mock<ITireRepository>(MockBehavior.Loose);
            this.mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            this.mockedTireSpecificationRepo = new Mock<ITireSpecificationRepository>(MockBehavior.Loose);
            this.tireShopLogic = this.tireShopLogic = new TireShopLogic(this.mockedTireRepo.Object, this.mockedBrandRepo.Object, this.mockedTireSpecificationRepo.Object);

            List<Brand> brands = new List<Brand>()
            {
                new Brand() { ID = 1, Name = "Continental", Headquarter = "Hungary", CEOName = "TESZT", CountryName = "Hungary", Factories = 10 },

                new Brand() { ID = 2, Name = "Hankook", Headquarter = "Marocco", CEOName = "TESZT", CountryName = "Hungary", Factories = 5 },
            };
            List<Tire> tires = new List<Tire>()
            {
                new Tire() { ID = 1, BrandID = 1, TireName = "SportContact3", Width = 200, AspectRatio = 50, Diameter = 16, Price = 1000 },
                new Tire() { ID = 2, BrandID = 1, Price = 3000, TireName = "SportContact3", AspectRatio = 40, Diameter = 15, Width = 205 },
                new Tire() { ID = 3, BrandID = 2, Price = 4000, TireName = "wINTERiCEPT", AspectRatio = 30, Diameter = 15, Width = 205 },
                new Tire() { ID = 4, BrandID = 2, Price = 6000, TireName = "EVO2", AspectRatio = 50, Diameter = 15, Width = 205 },
            };

            List<TireSpecification> tireSpecifications = new List<TireSpecification>()
            {
                new TireSpecification() { ID = 1, TireID = 1, ProductionCountryName = "Hungary", DOTNumber = 3020, LoadIndex = 210, ProductionWeek = 30, ProductionYear = 2020, SpeedRating = "T" },
                new TireSpecification() { ID = 2, TireID = 3, ProductionCountryName = "Hungary", DOTNumber = 3020, LoadIndex = 210, ProductionWeek = 30, ProductionYear = 2020, SpeedRating = "V" },
            };

            this.mockedBrandRepo.Setup(repo => repo.GetAll()).Returns(brands.AsQueryable());
            this.mockedTireRepo.Setup(repo => repo.GetAll()).Returns(tires.AsQueryable());
            this.mockedTireSpecificationRepo.Setup(repo => repo.GetAll()).Returns(tireSpecifications.AsQueryable());
        }
        

        /// <summary>
        /// Get all tire test.
        /// </summary>
        [Test]
        public void TestByGetAllTire()
        {
            this.tireShopLogic.GetAllTires();
            this.mockedTireRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Get all Brand test.
        /// </summary>
        [Test]
        public void TestByGetAllBrand()
        {
            this.tireShopLogic.GetAllBrands();
            this.mockedBrandRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// GEt all tire spec test.
        /// </summary>
        [Test]
        public void TestByGetAllTireSpec()
        {
            this.tireShopLogic.GetAllTireSpecifications();
            this.mockedTireSpecificationRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Test tire id.
        /// </summary>
        [Test]
        public void TestByGetOneTireByID()
        {
            int id = 1;
            this.tireShopLogic.GetTireById(id);
            this.mockedTireRepo.Verify(repo => repo.GetOne(id), Times.Once);
        }

        /// <summary>
        /// get brand by id test.
        /// </summary>
        [Test]
        public void TestByGetOneBrandByID()
        {
            int id = 1;
            this.tireShopLogic.GetBrandById(id);
            this.mockedBrandRepo.Verify(repo => repo.GetOne(id), Times.Once);
        }

        /// <summary>
        /// Get tire spec by id tesst.
        /// </summary>
        [Test]
        public void TestByGetOneTireSpecByID()
        {
            int id = 1;
            this.tireShopLogic.GetTireSpecificationById(id);
            this.mockedTireSpecificationRepo.Verify(repo => repo.GetOne(id), Times.Once);
        }

        /// <summary>
        /// trest brandavg.
        /// </summary>
        [Test]
        public void TestGetBrandAVG()
        {
            this.tireShopLogic = new TireShopLogic(this.mockedTireRepo.Object, this.mockedBrandRepo.Object, this.mockedTireSpecificationRepo.Object);
            List<AvarageResult> avarageResults = new List<AvarageResult>()
            {
                new AvarageResult() { BrandName = "Continental", AvaragePrice = 2000 },
                new AvarageResult() { BrandName = "Hankook", AvaragePrice = 5000 },
            };
            var asd = this.tireShopLogic.BrandAvarages();
            Assert.That(asd, Is.EquivalentTo(avarageResults));
            this.mockedBrandRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedTireRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Test hq madeofplace.
        /// </summary>
        [Test]
        public void TestHQMAdeOFPLaces()
        {
            this.tireShopLogic = new TireShopLogic(this.mockedTireRepo.Object, this.mockedBrandRepo.Object, this.mockedTireSpecificationRepo.Object);
            List<HQMadeofPlace> expectedResult = new List<HQMadeofPlace>()
            {
                new HQMadeofPlace() { BrandHQ = "Hungary", TireMadePlace = "Hungary", SamePlace = true },
            };
            string brname = "Continental";
            string trname = "SportContact3";
            var sad = this.tireShopLogic.HQMadeofPlaces(brname, trname);
            Assert.That(sad, Is.EquivalentTo(expectedResult));
            this.mockedBrandRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedTireRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedTireSpecificationRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Test tire recomm.
        /// </summary>
        [Test]
        public void TestTireRecommendations()
        {
            this.tireShopLogic = new TireShopLogic(this.mockedTireRepo.Object, this.mockedBrandRepo.Object, this.mockedTireSpecificationRepo.Object);
            List<TireRecommendation> expectedResult = new List<TireRecommendation>()
            {
                new TireRecommendation() { BrandName = "Continental", TireName = "SportContact3", Width = 200, AspectRatio = 50, Diameter = 16,  TirePrice = 1000 },
            };
            int maxPrice = 22000;
            int width = 200;
            int aspectRatio = 50;
            int diameter = 16;
            var sameplace = this.tireShopLogic.TireRecommendations(maxPrice, width, aspectRatio, diameter);
            Assert.That(sameplace, Is.EquivalentTo(expectedResult));
            this.mockedBrandRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedTireRepo.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
