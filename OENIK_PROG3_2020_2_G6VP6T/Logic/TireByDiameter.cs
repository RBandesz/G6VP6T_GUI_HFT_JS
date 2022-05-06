// <copyright file="ITireShopLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic
{
    public class TireByDiameter
    {
        public int Diameter { get; set; }
        public string BrandName { get; set; }
        public string TireName { get; set; }

        public override string ToString()
        {
            return $"Brand name = {this.BrandName} | Tirename = {this.TireName}, Diameter: {this.Diameter}";
        }

        public override int GetHashCode()
        {
            return this.BrandName.GetHashCode() + this.Diameter.GetHashCode() + this.TireName.GetHashCode();
        }
    }
}