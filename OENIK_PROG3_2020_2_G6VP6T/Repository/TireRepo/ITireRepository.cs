// <copyright file="ITireRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Repository.TireRepo
{
    using TireShop.Data.Tables;

    /// <summary>
    /// Interface.
    /// </summary>
    public interface ITireRepository : IRepository<Tire>
    {
        /// <summary>
        /// Can change price.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="newPrice">new price.</param>
        //void UpdatePrice(int id, int newPrice);
    }
}