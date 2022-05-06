// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<It ocnatians.>", Scope = "namespace", Target = "~N:TireShop.Logic.Logicinterfaces")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<valid.>", Scope = "member", Target = "~M:TireShop.Logic.TireShopLogic.HQMadeofPlaces(System.String,System.String)~System.Collections.Generic.IList{TireShop.Logic.HQMadeofPlace}")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<valid.>", Scope = "member", Target = "~M:TireShop.Logic.TireShopLogic.HQMadeofPlacesAsync(System.String,System.String)~System.Threading.Tasks.Task{System.Collections.Generic.List{TireShop.Logic.HQMadeofPlace}}")]
[assembly: SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "<valid.>", Scope = "member", Target = "~M:TireShop.Logic.TireShopLogic.HQMadeofPlacesAsync(System.String,System.String)~System.Threading.Tasks.Task{System.Collections.Generic.List{TireShop.Logic.HQMadeofPlace}}")]
[assembly: SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "<valid.>", Scope = "member", Target = "~M:TireShop.Logic.TireShopLogic.HQMadeofPlaces(System.String,System.String)~System.Collections.Generic.IList{TireShop.Logic.HQMadeofPlace}")]
[assembly: SuppressMessage("Design", "CA1065:Do not raise exceptions in unexpected locations", Justification = "<argumentnull.>", Scope = "member", Target = "~M:TireShop.Logic.HQMadeofPlace.Equals(System.Object)~System.Boolean")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<gethash.>", Scope = "member", Target = "~M:TireShop.Logic.HQMadeofPlace.GetHashCode~System.Int32")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "<valid.>", Scope = "member", Target = "~M:TireShop.Logic.AvarageResult.GetHashCode~System.Int32")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<not needed.>", Scope = "member", Target = "~M:TireShop.Logic.AvarageResult.GetHashCode~System.Int32")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<not needed.>", Scope = "member", Target = "~M:TireShop.Logic.TireRecommendation.GetHashCode~System.Int32")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<not.>", Scope = "member", Target = "~M:TireShop.Logic.ITireShopLogic.BrandAvarages~System.Collections.Generic.List{TireShop.Logic.AvarageResult}")]
