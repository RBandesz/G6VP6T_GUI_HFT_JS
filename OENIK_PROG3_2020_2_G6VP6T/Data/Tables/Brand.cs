// <copyright file="Brand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TireShop.Data.Tables
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json.Serialization;
    using TireShop.Data;

    /// <summary>
    /// Initializes a new instance of the Brand.
    /// </summary>
    [Table("Brand")]
    public class Brand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Brand"/> class.
        /// </summary>
        public Brand()
        {
            this.Tires = new HashSet<Tire>();
        }

        /// <summary>
        /// Gets or sets and sets ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets and sets ID.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets and sets CountryName.
        /// </summary>
        [MaxLength(100)]
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets and sets Headquarter.
        /// </summary>
        [MaxLength(100)]
        public string Headquarter { get; set; }

        /// <summary>
        /// Gets or sets and sets CEOName.
        /// </summary>
        [MaxLength(50)]
        public string CEOName { get; set; }

        /// <summary>
        /// Gets or sets and sets Factories.
        /// </summary>
        public int Factories { get; set; }

        

        /// <summary>
        /// Gets or sets and sets Tires.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Tire> Tires { get; set; }

        /// <summary>
        /// Generate string.
        /// </summary>
        /// <returns>x as a string.</returns>
        public override string ToString()
        {
            string x = string.Empty;

            x += "   ";
            x += "Brand name:\t=> ";
            x += this.Name;
            x += "\n";
            x += "   ";
            x += "Brand HQ:\t=> ";
            x += this.Headquarter;
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
