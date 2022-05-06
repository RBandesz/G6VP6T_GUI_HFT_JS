// <copyright file="TireRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Repository.TireRepo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using TireShop.Data;
    using TireShop.Data.Tables;

    /// <summary>
    /// Initializes a new instance of the TireRepository class.
    /// </summary>
    public class TireRepository : Repo<Tire>, ITireRepository, IRepository<Tire>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TireRepository"/> class.
        /// </summary>
        /// <param name="ctx">Dbcontext.</param>
        public TireRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Can change the price.
        /// </summary>
        /// <param name="id">tire id.</param>
        /// <param name="newPrice">newPrice.</param>
        //public void UpdatePrice(int id, int newPrice)
        //{
        //    var tire = this.GetOne(id);
        //    if (tire == null)
        //    {
        //        throw new InvalidOperationException("not found");
        //    }

        //    tire.Price = newPrice;
        //    this.ctx.SaveChanges();
        //}

        /// <summary>
        /// Get one tire.
        /// </summary>
        /// <param name="id">tire id.</param>
        /// <returns>with one tire.</returns>
        public override Tire GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ID == id);
        }

        public override void Update(Tire item)
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
    }
}
