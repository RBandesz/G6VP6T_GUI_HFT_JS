// <copyright file="AvarageResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// AvarageResult class.
    /// </summary>
    public class AvarageResult
    {
        /// <summary>
        /// Gets or sets indentify a brandName.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets set the AVG price.
        /// </summary>
        public double AvaragePrice { get; set; }

        /// <summary>
        /// Create a string.
        /// </summary>
        /// <returns>with a string.</returns>
        public override string ToString()
        {
            return $"Brand = {this.BrandName}, AVG = {this.AvaragePrice}";
        }

        /// <summary>
        /// Equals method.
        /// </summary>
        /// <param name="obj">bool.</param>
        /// <returns>With equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is AvarageResult)
            {
                AvarageResult other = obj as AvarageResult;
                return this.BrandName == other.BrandName && this.AvaragePrice == other.AvaragePrice;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Override gethash code.
        /// </summary>
        /// <returns>with a string.</returns>
        public override int GetHashCode()
        {
            return BrandName.GetHashCode() + (int)this.AvaragePrice;
        }
    }
}
