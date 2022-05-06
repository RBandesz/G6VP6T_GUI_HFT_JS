// <copyright file="IBrandRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Repository.BrandRepo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TireShop.Data.Tables;

    /// <summary>
    /// BrandRepo interface.
    /// </summary>
    public interface IBrandRepository : IRepository<Brand>
    {
        /// <summary>
        /// Update brand ceo.
        /// </summary>
        /// <param name="id">brand id.</param>
        /// <param name="newCEO">new ceo.</param>
        //void UpdateBrandCEO(int id, string newCEO);
    }
}
