// <copyright file="ITireSpecificationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Repository.TireSpecificationRepo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TireShop.Data.Tables;

    /// <summary>
    /// Tire Spec repo.
    /// </summary>
    public interface ITireSpecificationRepository : IRepository<TireSpecification>
    {
        /// <summary>
        /// Tire speed rating.
        /// </summary>
        /// <param name="id">tirespec id.</param>
        /// <param name="newSpeedRating">new speed rating.</param>
        //void UpdateTireSpecificationSpeedRating(int id, string newSpeedRating);
    }
}
