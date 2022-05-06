// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Repository
{
    using System.Linq;

    /// <summary>
    /// Interface documentation.
    /// </summary>
    /// <typeparam name="T">T param.</typeparam>
    public interface IRepository<T> 
        where T : class
    {
        /// <summary>
        /// Create a new entity.
        /// </summary>
        /// <param name="entity">Brand, Tire, TireSpec.</param>
        public void Create(T entity);

        /// <summary>
        /// Delete a Brand, Tire or Spec.
        /// </summary>
        /// <param name="id">Bradn tire or spec id.</param>
        public void Delete(int id);
        void Update(T item);
        /// <summary>
        /// Get one doc.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Item id.</returns>
        T GetOne(int id);

        /// <summary>
        /// Get all tire.
        /// </summary>
        /// <returns>With all tire.</returns>
        IQueryable<T> GetAll();
    }
}