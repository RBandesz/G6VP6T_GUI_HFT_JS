// <copyright file="LogicAdministration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic.Logics
{
    using TireShop.Data;
    using TireShop.Data.Tables;
    using TireShop.Logic.Logicinterfaces;
    using TireShop.Repository.BrandRepo;
    using TireShop.Repository.TireRepo;
    using TireShop.Repository.TireSpecificationRepo;

    /// <summary>
    /// Logic Admin.
    /// </summary>
    public class LogicAdministration : ILogicAdministration
    {
        private ITireRepository tireRepo;
        private IBrandRepository brandRepo;
        private ITireSpecificationRepository tireSpecificationRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicAdministration"/> class.
        /// </summary>
        /// <param name="tireRepo">tireRepo specified.</param>
        /// <param name="brandRepo">brandRepo specified.</param>
        /// <param name="tireSpecificationRepo">tireSpecificationRepo specified..</param>
        public LogicAdministration(ITireRepository tireRepo, IBrandRepository brandRepo, ITireSpecificationRepository tireSpecificationRepo)
        {
            this.tireRepo = tireRepo;
            this.brandRepo = brandRepo;
            this.tireSpecificationRepo = tireSpecificationRepo;
        }

        /// <summary>
        /// Create a new brand.
        /// </summary>
        /// <param name="newBrand">brand param.</param>
        public void CrateNewBrand(Brand newBrand)
        {
            this.brandRepo.Create(newBrand);
        }

        /// <summary>
        /// Create new tire.
        /// </summary>
        /// <param name="newTire">tire param.</param>
        public void CrateNewTire(Tire newTire)
        {
            this.tireRepo.Create(newTire);
        }

        /// <summary>
        /// create new tire spec.
        /// </summary>
        /// <param name="newTireSpecification">trie sepc.</param>
        public void CrateNewTireSpecification(TireSpecification newTireSpecification)
        {
            this.tireSpecificationRepo.Create(newTireSpecification);
        }

        /// <summary>
        /// Remove brand.
        /// </summary>
        /// <param name="id">removable id.</param>
        public void RemoveNewBrand(int id)
        {
            this.brandRepo.Delete(id);
        }

        /// <summary>
        /// Remove tire.
        /// </summary>
        /// <param name="id">removable id.</param>
        public void RemoveNewTire(int id)
        {
            this.tireRepo.Delete(id);
        }

        /// <summary>
        /// Remove tire spec.
        /// </summary>
        /// <param name="id">removable id.</param>
        public void RemoveNewTireSpecification(int id)
        {
            this.tireSpecificationRepo.Delete(id);
        }

        public void UpdateTire(Tire item)
        {
            this.tireRepo.Update(item);
        }

        public void UpdateBrand(Brand item)
        {
            this.brandRepo.Update(item);
        }

        public void UpdateTireSpec(TireSpecification item)
        {
            this.tireSpecificationRepo.Update(item);
        }

        ///// <summary>
        ///// Update brand ceo.
        ///// </summary>
        ///// <param name="id">brand id.</param>
        ///// <param name="newCEO">new ceo name.</param>
        //public void (int id, string newCEO)
        //{
        //    this.brandRepo.UpdateBrandCEO(id, newCEO);
        //}

        ///// <summary>
        ///// New Tire price.
        ///// </summary>
        ///// <param name="id">tire id.</param>
        ///// <param name="newPrice">new price.</param>
        //public void UpdateTirePrice(int id, int newPrice)
        //{
        //    this.tireRepo.UpdatePrice(id, newPrice);
        //}

        ///// <summary>
        ///// New speed rate.
        ///// </summary>
        ///// <param name="id">tire spec id.</param>
        ///// <param name="newSpeedRating">speed rating.</param>
        //public void UpdateTireSpecificationSpeedRating(int id, string newSpeedRating)
        //{
        //    this.tireSpecificationRepo.UpdateTireSpecificationSpeedRating(id, newSpeedRating);
        //}
    }
}
