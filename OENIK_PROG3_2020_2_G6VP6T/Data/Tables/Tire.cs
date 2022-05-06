// <copyright file="Tire.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Data.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks.Sources;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
    using TireShop.Data.Tables;

    /// <summary>
    /// Gets or sets TireSize.
    /// </summary>
    [Table("Tire")]
    public class Tire
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tire"/> class.
        /// Tire ctor.
        /// </summary>
        public Tire()
        {
            this.TireSpecifications = new HashSet<TireSpecification>();
        }

        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets BrandID.
        /// </summary>
        [ForeignKey(nameof(Brand))]
        [ToString]
        public int BrandID { get; set; }

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        [Required]
        [ToString]
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets Width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets AspectRatio.
        /// </summary>
        public int AspectRatio { get; set; }

        /// <summary>
        /// Gets or sets Diameter.
        /// </summary>
        public int Diameter { get; set; }

        /// <summary>
        /// Gets or sets TireName.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string TireName { get; set; }

        /// <summary>
        /// Gets or sets Brand.
        /// </summary>
        [NotMapped]
        public virtual Brand Brand { get; set; }
        [NotMapped]
        public virtual TireSpecification TireSpecification{ get; set; }

        /// <summary>
        /// Gets or sets and sets TireSpecifications.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<TireSpecification> TireSpecifications { get; set; }

        /// <summary>
        /// Write the ToString method.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            string x = string.Empty;

            x += "   ";
            x += "Brand name:\t=> ";
           // x += this.Brand.Name;
            x += "\n";
            x += "   ";
            x += "Tire name:\t=> ";
            x += this.TireName;
            x += "\n";
            foreach (var item in this.GetType().GetProperties().Where(x =>
               x.GetCustomAttribute<ToStringAttribute>() != null))
            {
                x += "   ";
                x += item.Name + "\t=> ";
                x += item.GetValue(this);
                x += "\n";
            }

            return x;
        }
    }
}
