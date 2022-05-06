// <copyright file="ITireShopLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Logic
{
    public class TirePriceSUM
    {
        public string BrandName { get; set; }
        public int PriceSum { get; set; }

        public override string ToString()
        {
            return $"BrandName = {this.BrandName}, BrandSUM= {this.PriceSum}";
        }

        public override int GetHashCode()
        {
            return this.BrandName.GetHashCode() + this.PriceSum.GetHashCode();
        }
    }
}