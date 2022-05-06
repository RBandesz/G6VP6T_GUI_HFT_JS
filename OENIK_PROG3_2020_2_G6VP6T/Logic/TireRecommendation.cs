// <copyright file="TireRecommendation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Recommend a tire.
    /// </summary>
    public class TireRecommendation
    {
        /// <summary>
        /// Gets or sets brand name.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets tire name.
        /// </summary>
        public string TireName { get; set; }

        /// <summary>
        /// Gets or sets tire price.
        /// </summary>
        public int TirePrice { get; set; }

        /// <summary>
        /// Gets or sets max price.
        /// </summary>
        public int MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets tire width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets tire aspect ratio.
        /// </summary>
        public int AspectRatio { get; set; }

        /// <summary>
        /// Gets or sets tire diameter.
        /// </summary>
        public int Diameter { get; set; }

        /// <summary>
        /// Creates a string.
        /// </summary>
        /// <returns>with a string.</returns>
        public override string ToString()
        {
            return $"Recommended tires: {this.BrandName}  {this.TireName}  {this.Width}/{this.AspectRatio}R{this.Diameter} | {this.TirePrice}";
        }

        /// <summary>
        /// Analyzing it has the same value.
        /// </summary>
        /// <param name="obj">Tirerecomm obj.</param>
        /// <returns>with a bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is TireRecommendation)
            {
                TireRecommendation other = obj as TireRecommendation;
                return this.BrandName == other.BrandName &&
                    this.TireName == other.TireName &&
                    this.Width == other.Width &&
                    this.AspectRatio == other.AspectRatio &&
                    this.Diameter == other.Diameter &&
                    this.TirePrice == other.TirePrice;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Give back an int.
        /// </summary>
        /// <returns>With a value.</returns>
        public override int GetHashCode()
        {
            return this.BrandName.GetHashCode() + this.TireName.GetHashCode() + this.Width.GetHashCode() + this.AspectRatio.GetHashCode() + this.Diameter.GetHashCode() + (int)this.TirePrice;
        }
    }
}
