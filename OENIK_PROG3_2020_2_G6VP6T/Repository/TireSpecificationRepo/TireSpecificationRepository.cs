// <copyright file="TireSpecificationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Repository.TireSpecificationRepo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using TireShop.Data;
    using TireShop.Data.Tables;

    /// <summary>
    /// Tire Spec class.
    /// </summary>
    public class TireSpecificationRepository : Repo<TireSpecification>, ITireSpecificationRepository, IRepository<TireSpecification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TireSpecificationRepository"/> class.
        /// </summary>
        /// <param name="ctx">db obj.</param>
        public TireSpecificationRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Tire Spec.
        /// </summary>
        /// <param name="id">Tire spec id.</param>
        /// <returns>with a tire spec.</returns>
        public override TireSpecification GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ID == id);
        }

        public override void Update(TireSpecification item)
        {
            var old = GetOne(item.ID);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }

        /// <summary>
        /// SpeedRating change.
        /// </summary>
        /// <param name="id">tire spec id.</param>
        /// <param name="newSpeedRating">new speed rating.</param>
        //public void UpdateTireSpecificationSpeedRating(int id, string newSpeedRating)
        //{
        //    var tire = this.GetOne(id);
        //    if (tire == null)
        //    {
        //        throw new InvalidOperationException("not found");
        //    }

        //    tire.SpeedRating = newSpeedRating;
        //    this.ctx.SaveChanges();
        //}
    }
}
