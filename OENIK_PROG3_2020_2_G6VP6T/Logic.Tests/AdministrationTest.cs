// <copyright file="AdministrationTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic.Tests
{
    using Moq;
    using NUnit.Framework;
    using TireShop.Data;
    using TireShop.Data.Tables;
    using TireShop.Logic.Logics;
    using TireShop.Repository.BrandRepo;
    using TireShop.Repository.TireRepo;
    using TireShop.Repository.TireSpecificationRepo;

    /// <summary>
    /// AdminTest class.
    /// </summary>
    [TestFixture]
    public class AdministrationTest
    {
        private Mock<ITireRepository> mockedTireRepo = new Mock<ITireRepository>(MockBehavior.Loose);
        private Mock<IBrandRepository> mockedBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
        private Mock<ITireSpecificationRepository> mockedTireSpecificationRepo = new Mock<ITireSpecificationRepository>(MockBehavior.Loose);
        private LogicAdministration logicAdministration;

        /// <summary>
        /// Setup method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.logicAdministration = new LogicAdministration(this.mockedTireRepo.Object, this.mockedBrandRepo.Object, this.mockedTireSpecificationRepo.Object);
        }

        /// <summary>
        /// Create menu testing.
        /// </summary>
        [Test]
        public void TestByCreateBrand()
        {
            Brand brand = new Brand()
            {
                Name = "test_Brand",
                Factories = 10,
                CEOName = "tecst_CEO",
                CountryName = "test_country",
                Headquarter = "test_HQ",
            };

            this.logicAdministration.CrateNewBrand(brand);
            this.mockedBrandRepo.Verify(repo => repo.Create(brand), Times.Once);
            this.mockedBrandRepo.Verify(repo => repo.Create(It.IsAny<Brand>()), Times.Once);
        }

        /// <summary>
        /// Crate tire test.
        /// </summary>
        [Test]
        public void TestByCreateTire()
        {
            Tire tire = new Tire()
            {
                TireName = "test_tire",
                BrandID = 2,
                AspectRatio = 12,
                Width = 12,
                Price = 1010,
                Diameter = 20,
            };

            this.logicAdministration.CrateNewTire(tire);
            this.mockedTireRepo.Verify(repo => repo.Create(tire), Times.Once);
            this.mockedTireRepo.Verify(repo => repo.Create(It.IsAny<Tire>()), Times.Once);
        }

        /// <summary>
        /// Create tire spec test.
        /// </summary>
        [Test]
        public void TestByCreateTireSpecification()
        {
            TireSpecification tireSpecification = new TireSpecification()
            {
                TireID = 1,
                DOTNumber = 1234,
                LoadIndex = 123,
                SpeedRating = "a",
                ProductionCountryName = "test",
                ProductionWeek = 12,
                ProductionYear = 34,
            };

            this.logicAdministration.CrateNewTireSpecification(tireSpecification);
            this.mockedTireSpecificationRepo.Verify(repo => repo.Create(tireSpecification), Times.Once);
            this.mockedTireRepo.Verify(repo => repo.Create(It.IsAny<Tire>()), Times.Once);
        }

        /// <summary>
        /// Delete tire test.
        /// </summary>
        [Test]
        public void TestByDeleteTire()
        {
            int id = 1;
            this.logicAdministration.RemoveNewTire(id);
            this.mockedTireRepo.Verify(repo => repo.Delete(id), Times.Once);
        }

        /// <summary>
        /// Delete brand test.
        /// </summary>
        [Test]
        public void TestByDeleteBrand()
        {
            int id = 1;
            this.logicAdministration.RemoveNewBrand(id);
            this.mockedBrandRepo.Verify(repo => repo.Delete(id), Times.Once);
        }

        /// <summary>
        /// DElete tire spec test.
        /// </summary>
        [Test]
        public void TestByDeleteTireSpecification()
        {
            int id = 1;
            this.logicAdministration.RemoveNewTireSpecification(id);
            this.mockedTireSpecificationRepo.Verify(repo => repo.Delete(id), Times.Once);
        }

        ///// <summary>
        ///// Change tire price  test.
        ///// </summary>
        //[Test]
        //public void TestByUpdateTirePrice()
        //{
        //    Tire

        //    this.logicAdministration.UpdateTire();
        //    this.mockedTireRepo.Verify(repo => repo.UpdatePrice(id, newPrice), Times.Once);
        //}

        ///// <summary>
        ///// Change ceo test.
        ///// </summary>
        //[Test]
        //public void TestByUpdateBrandCEO()
        //{
        //    int id = 1;
        //    string newCEO = "test_ceo";

        //    this.logicAdministration.UpdateBrandCEO(id, newCEO);
        //    this.mockedBrandRepo.Verify(repo => repo.UpdateBrandCEO(id, newCEO), Times.Once);
        //}

        ///// <summary>
        ///// change speedrating test.
        ///// </summary>
        //[Test]
        //public void TestByUpdateSpeedRating()
        //{
        //    int id = 1;
        //    string newSpeedRating = "test_sp";

        //    this.logicAdministration.UpdateTireSpecificationSpeedRating(id, newSpeedRating);
        //    this.mockedTireSpecificationRepo.Verify(repo => repo.UpdateTireSpecificationSpeedRating(id, newSpeedRating), Times.Once);
        //}
    }
}
