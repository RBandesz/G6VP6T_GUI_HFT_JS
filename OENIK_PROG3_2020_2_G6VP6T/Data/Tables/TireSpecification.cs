// <copyright file="TireSpecification.cs" company="PlaceholderCompany">
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
    using TireShop.Data.Tables;

    /// <summary>
    /// Initializes a new instance of the TireSpecifications.
    /// </summary>
    [Table("TireSpecification")]
    public class TireSpecification
    {
        public TireSpecification()
        {
            this.Tires = new HashSet<Tire>();
        }
        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets BrandID.
        /// </summary>
        [ForeignKey(nameof(Tire))]
        [Required]
        public int TireID { get; set; }

        /// <summary>
        /// Gets or sets CountryName.
        /// </summary>
        [MaxLength(100)]
        public string ProductionCountryName { get; set; }

        /// <summary>
        /// Gets or sets DOTNumber.
        /// </summary>
        public int DOTNumber { get; set; }

        /// <summary>
        /// Gets or sets ProductionYear.
        /// </summary>
        public int ProductionYear { get; set; }

        /// <summary>
        /// Gets or sets ProductionWeek.
        /// </summary>
        public int ProductionWeek { get; set; }

        /// <summary>
        /// Gets or sets LoadIndex.
        /// </summary>
        public int LoadIndex { get; set; }

        /// <summary>
        /// Gets or sets SpeedRating.
        /// </summary>
        public string SpeedRating { get; set; }

        /// <summary>
        /// Gets or sets Brand.
        /// </summary>
        [NotMapped]
        public virtual Tire Tire { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Tire> Tires { get; set; }

        /// <summary>
        /// Write the ToString method.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            string x = string.Empty;

            x += "   ";
            x += "\n";
            x += "   ";
            x += "Tire name:\t=> ";
            //x += this.Tire.TireName;
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
