// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Database supr>", Scope = "member", Target = "~M:TireShop.Data.TireDbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<modelbuilder>", Scope = "member", Target = "~M:TireShop.Data.TireDbContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Supressed>", Scope = "member", Target = "~P:TireShop.Data.Tables.Brand.Tires")]
[assembly: SuppressMessage("Design", "CA1018:Mark attributes with AttributeUsageAttribute", Justification = "<Not important>", Scope = "type", Target = "~T:TireShop.Data.ToStringAttribute")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Supressed>", Scope = "member", Target = "~P:TireShop.Data.Tire.TireSpecifications")]
[assembly: SuppressMessage("Performance", "CA1813:Avoid unsealed attributes", Justification = "<No attributes yet.>", Scope = "type", Target = "~T:TireShop.Data.ToStringAttribute")]
[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
