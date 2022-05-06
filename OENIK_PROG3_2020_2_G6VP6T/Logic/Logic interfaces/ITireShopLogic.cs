// <copyright file="ITireShopLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TireShop.Data;
    using TireShop.Data.Tables;

    /// <summary>
    /// ITireShopLogic class.
    /// </summary>
    public interface ITireShopLogic
    {
        /// <summary>
        /// Gets a tire.
        /// </summary>
        /// <param name="id">tireid.</param>
        /// <returns>with a tire.</returns>
        Tire GetTireById(int id);

        /// <summary>
        /// Get abrand by id.
        /// </summary>
        /// <param name="id">brand id's.</param>
        /// <returns>with a brand.</returns>
        Brand GetBrandById(int id);

        /// <summary>
        /// Get TireSpecification by id.
        /// </summary>
        /// <param name="id">TireSpecification id's.</param>
        /// <returns>with a TireSpecification.</returns>
        TireSpecification GetTireSpecificationById(int id);

        

        /// <summary>
        /// Get all tires in a list.
        /// </summary>
        /// <returns>With a list.</returns>
        IList<Tire> GetAllTires();

        /// <summary>
        /// Get all Brands in a list.
        /// </summary>
        /// <returns>with all brands.</returns>
        IList<Brand> GetAllBrands();

        /// <summary>
        /// Get all TireSpecification in a list.
        /// </summary>
        /// <returns>with all TireSpecification.</returns>
        IList<TireSpecification> GetAllTireSpecifications();

        /// <summary>
        /// Get the avarages price per brand.
        /// </summary>
        /// <returns>with avg prices.</returns>
        IList<AvarageResult> BrandAvarages();
        IList<TirePriceSUM> TirePriceSUMs();
        IList<TireByDiameter> TireByDiameters(int diameter);

        /// <summary>
        /// See if the hq country same with the production country.
        /// </summary>
        /// <param name="brandName">brand name.</param>
        /// <param name="tireName">tire name.</param>
        /// <returns>brand hq country, tire production country, is the same bool.</returns>
        IList<HQMadeofPlace> HQMadeofPlaces(string brandName, string tireName);

        /// <summary>
        /// Picks you a tire you should buy.
        /// </summary>
        /// <param name="maxPrice">your buget.</param>
        /// <param name="width">your tires width.</param>
        /// <param name="aspectRatio">your tires aspectRatio.</param>
        /// <param name="diameter">your tires diameter.</param>
        /// <returns>with the selected tire for you.</returns>
        IList<TireRecommendation> TireRecommendations(int maxPrice, int width, int aspectRatio, int diameter);

        /// <summary>
        /// Get the avarages price per brand.
        /// </summary>
        /// <returns>with avg prices.</returns>
        Task<List<AvarageResult>> BrandAvaragesAsync();

        /// <summary>
        /// See if the hq country same with the production country.
        /// </summary>
        /// <param name="brandName">brand name.</param>
        /// <param name="tireName">tire name.</param>
        /// <returns>brand hq country, tire production country, is the same bool.</returns>
        Task<List<HQMadeofPlace>> HQMadeofPlacesAsync(string brandName, string tireName);

        /// <summary>
        /// Picks you a tire you should buy.
        /// </summary>
        /// <param name="maxPrice">your buget.</param>
        /// <param name="width">your tires width.</param>
        /// <param name="aspectRatio">your tires aspectRatio.</param>
        /// <param name="diameter">your tires diameter.</param>
        /// <returns>with the selected tire for you.</returns>
        Task<List<TireRecommendation>> TireRecommendationsAsync(int maxPrice, int width, int aspectRatio, int diameter);
    }
}
