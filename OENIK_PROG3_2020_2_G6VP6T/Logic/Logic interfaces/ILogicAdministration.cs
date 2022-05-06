// <copyright file="ILogicAdministration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic.Logicinterfaces
{
    using TireShop.Data;
    using TireShop.Data.Tables;

    /// <summary>
    /// Initializes ILogicAdministration.
    /// </summary>
    public interface ILogicAdministration
    {
        void UpdateTire(Tire item);
        void UpdateBrand(Brand item);
        void UpdateTireSpec(TireSpecification item);
        /// <summary>
        /// Create a new brand.
        /// </summary>
        /// <param name="newBrand">A brand type newBrand obj.</param>
        public void CrateNewBrand(Brand newBrand);

        /// <summary>
        /// Create a new tire.
        /// </summary>
        /// <param name="newTire">A tire type newTire obj.</param>
        public void CrateNewTire(Tire newTire);

        /// <summary>
        /// Create a new tirepec.
        /// </summary>
        /// <param name="newTireSpecification">A tirespec type tirespec obj.</param>
        public void CrateNewTireSpecification(TireSpecification newTireSpecification);

        /// <summary>
        /// Delete a brand.
        /// </summary>
        /// <param name="id">Brand id.</param>
        public void RemoveNewBrand(int id);

        /// <summary>
        /// Delete a tire.
        /// </summary>
        /// <param name="id">Tire id.</param>
        public void RemoveNewTire(int id);

        /// <summary>
        /// Delete a tirespec.
        /// </summary>
        /// <param name="id">tirespec id.</param>
        public void RemoveNewTireSpecification(int id);

        ///// <summary>
        ///// modify a brand ceo.
        ///// </summary>
        ///// /// <param name="id">Modifyed id. </param>
        ///// <param name="newCEO">The new CEO.</param>
        //public void UpdateBrandCEO(int id, string newCEO);

        ///// <summary>
        ///// udpate a tire price.
        ///// </summary>
        ///// <param name="id">Modifyed id. </param>
        ///// <param name="newPrice">new price.</param>
        //public void UpdateTirePrice(int id, int newPrice);

        ///// <summary>
        ///// update speed rating.
        ///// </summary>
        ///// <param name="id">Modifyed id.</param>
        ///// <param name="newSpeedRating">new speedrating.</param>
        //public void UpdateTireSpecificationSpeedRating(int id, string newSpeedRating);
    }
}
