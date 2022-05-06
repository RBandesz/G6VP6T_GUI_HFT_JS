// <copyright file="HQMadeofPlace.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// HQMAdeofplace.
    /// </summary>
    public class HQMadeofPlace
    {
        /// <summary>
        /// Gets or sets brandHQ.
        /// </summary>
        public string BrandHQ { get; set; }

        /// <summary>
        /// Gets or sets tirePLAce.
        /// </summary>
        public string TireMadePlace { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether bool Same place.
        /// </summary>
        public bool SamePlace { get; set; }

        /// <summary>
        /// Makes a string.
        /// </summary>
        /// <returns>returns a string.</returns>
        public override string ToString()
        {
            return $"BrandHQ = {this.BrandHQ}, Made of Place = {this.TireMadePlace}, same: {this.SamePlace}";
        }

        /// <summary>
        /// Equals.
        /// </summary>
        /// <param name="obj">get a tire name.</param>
        /// <returns>with a bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is HQMadeofPlace)
            {
                HQMadeofPlace other = obj as HQMadeofPlace;
                return this.BrandHQ == other.BrandHQ &&
                    this.TireMadePlace == other.TireMadePlace &&
                    this.SamePlace == other.SamePlace;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Override gethash code.
        /// </summary>
        /// <returns>with a get.</returns>
        public override int GetHashCode()
        {
            return this.BrandHQ.GetHashCode() + this.TireMadePlace.GetHashCode() + this.SamePlace.GetHashCode();
        }
    }
}