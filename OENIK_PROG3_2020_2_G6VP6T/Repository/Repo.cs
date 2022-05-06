// <copyright file="Repo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using TireShop.Data.Tables;

    /// <summary>
    /// Repo class.
    /// </summary>
    /// <typeparam name="T">Generic param.</typeparam>
    public abstract class Repo<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Ctx.
        /// </summary>
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repo{T}"/> class.
        /// Repo ctr.
        /// </summary>
        /// <param name="ctx">ctx generic obj.</param>
        public Repo(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Create a new entity.
        /// </summary>
        /// <param name="entity">Tire, Brand or spec.</param>
        public void Create(T entity)
        {
            this.ctx.Set<T>().Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Delete an existing entity.
        /// </summary>
        /// <param name="id">Brand or tire or spec id.</param>
        public void Delete(int id)
        {
            this.ctx.Set<T>().Remove(this.GetOne(id));
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Get all tire.
        /// </summary>
        /// <returns>with all tire.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Get one.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>only wiht one.</returns>
        public abstract T GetOne(int id);
        public abstract void Update(T item);
    }
}