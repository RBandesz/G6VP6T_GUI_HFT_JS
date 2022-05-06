// <copyright file="BrandRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Repository.BrandRepo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using TireShop.Data.Tables;

    /// <summary>
    /// BrandRepo class.
    /// </summary>
    public class BrandRepository : Repo<Brand>, IBrandRepository, IRepository<Brand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandRepository"/> class.
        /// </summary>
        /// <param name="ctx">return with db obj.</param>
        public BrandRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Get one method.
        /// </summary>
        /// <param name="id">bradn id.</param>
        /// <returns>Get brand.</returns>
        public override Brand GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ID == id);
        }

        public override void Update(Brand item)
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
        /// Update a brand CEO.
        /// </summary>
        /// <param name="id">brand id.</param>
        /// <param name="newCEO">new ceo.</param>
        //public void UpdateBrandCEO(int id, string newCEO)
        //{
        //    var tire = this.GetOne(id);
        //    if (tire == null)
        //    {
        //        throw new InvalidOperationException("not found");
        //    }

        //    tire.CEOName = newCEO;
        //    this.ctx.SaveChanges();
        //}
    }
}
