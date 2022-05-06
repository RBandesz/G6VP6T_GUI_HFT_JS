// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleTools;
    using TireShop.Data;
    using TireShop.Data.Tables;
    using TireShop.Logic;
    using TireShop.Logic.Logics;
    using TireShop.Repository.BrandRepo;
    using TireShop.Repository.TireRepo;
    using TireShop.Repository.TireSpecificationRepo;

    /// <summary>
    /// Program.
    /// </summary>
    internal class Program
    {
        private static TireDbContext ctx = new TireDbContext();
        private static TireRepository tireRepo = new TireRepository(ctx);
        private static BrandRepository brandRepo = new BrandRepository(ctx);
        private static TireSpecificationRepository tireSpecificationRepository = new TireSpecificationRepository(ctx);
        private static LogicAdministration logicAdd = new LogicAdministration(tireRepo, brandRepo, tireSpecificationRepository);
        private static LogicAdministration logicRemove = new LogicAdministration(tireRepo, brandRepo, tireSpecificationRepository);
        private static LogicAdministration logicUpdate = new LogicAdministration(tireRepo, brandRepo, tireSpecificationRepository);
        private static TireShopLogic logic = new TireShopLogic(tireRepo, brandRepo, tireSpecificationRepository);

        /// <summary>
        /// Main program.
        /// </summary>
        private static void Main()
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            var menu = new ConsoleMenu()
                .Add(">>Administration", () => AdministrationMenu())
                .Add(">>Products", () => ListMenu())
                .Add(">>EXIT", ConsoleMenu.Close);
            menu.Show();
        }

        private static void AdministrationMenu()
        {
            var menu = new ConsoleMenu()
                .Add(">>Create", () => CreateMenu())
                .Add(">>Delete", () => DeleteMenu())
                //.Add(">>Update", () => UpdateMenu())
                .Add(">>Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void ListMenu()
        {
            var menu = new ConsoleMenu()
                .Add(">>List all", () => ListAllMenu(logic))
                .Add(">>List by ID", () => ListByIDMenu(logic))
                .Add(">>HQ and Made of Place equals", () => MadeOfPLaceSame(logic))
                .Add(">>HQ and Made of Place equals (ASYNC)", () => MadeOfPLaceSameAsync(logic))
                .Add(">>Get Brand AVG", () => GetBrandAVG(logic))
                .Add(">>Get Brand AVG (ASYNC)", () => GetBrandAVGASYNC(logic))
                .Add(">>I would like to buy a tire", () => TireRecommendation(logic))
                .Add(">>I would like to buy a tire (ASYNC)", () => TireRecommendation(logic))
                .Add(">>Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void ListAllMenu(TireShopLogic logic)
        {
            var menu = new ConsoleMenu()
                .Add(">>List all Brand", () => ListAllBrands(logic))
                .Add(">>List all tire", () => ListAllTire(logic))
                .Add(">>List all Tire Spec", () => ListAllTireSpecifications(logic))
                .Add(">>Back",  ConsoleMenu.Close);
            menu.Show();
        }

        private static void ListByIDMenu(TireShopLogic logic)
        {
            var menu = new ConsoleMenu()
                .Add(">>Get Brand by ID", () => GetBrandById(logic))
                .Add(">>Get Tire by ID", () => GetTireById(logic))
                .Add(">>Get Tire Specification by ID", () => GetTireSpecificationById(logic))
                .Add(">>Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void CreateMenu()
        {
            var menu = new ConsoleMenu()
                .Add(">>Create new Brand", () => Create(logicAdd, 1))
                .Add(">>Create new Tire", () => Create(logicAdd, 2))
                .Add(">>Create new TireSpecification", () => Create(logicAdd, 3))
                .Add(">>Back", ConsoleMenu.Close);
            menu.Show();
        }

        //private static void UpdateMenu()
        //{
        //    var menu = new ConsoleMenu()
        //        .Add(">>Modify Tire price", () => ChangePrice(logic))
        //        .Add(">>Modify Speed Rating", () => ChangeSpeedRating(logicUpdate))
        //        .Add(">>Modify brand CEO", () => ChangeBrandCEO(logicUpdate))
        //        .Add(">>Back", ConsoleMenu.Close);
        //    menu.Show();
        //}

        private static void DeleteMenu()
        {
            var menu = new ConsoleMenu()
                .Add(">>Delete Brand", () => Delete(logicRemove, 1))
                .Add(">>Delete Tire", () => Delete(logicRemove, 2))
                .Add(">>Delete TireSpecification", () => Delete(logicRemove, 3))
                .Add(">>Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void Delete(LogicAdministration logicRemove, int v)
        {
            Console.WriteLine("\n:: Please enter the ID! ::\n");
            bool format = false;
            int id = 0;
            do
            {
                try
                {
                    id = int.Parse(Console.ReadLine());
                    format = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong id format id must be number! Please Try again!");
                }
            }
            while (format == false);
            switch (v)
            {
                case 1:
                    if (logic.GetBrandById(id) == null)
                    {
                        Console.WriteLine("There is no Brand with this ID!");
                    }
                    else
                    {
                        logicRemove.RemoveNewBrand(id);
                    }

                    break;
                case 2:
                    if (logic.GetTireById(id) == null)
                    {
                        Console.WriteLine("There is no Tire with this ID!");
                    }
                    else
                    {
                        logicRemove.RemoveNewTire(id);
                    }

                    break;
                case 3:
                    if (logic.GetTireSpecificationById(id) == null)
                    {
                        Console.WriteLine("There is no Videocard with this ID!");
                    }
                    else
                    {
                        logicRemove.RemoveNewTireSpecification(id);
                    }

                    break;
            }
        }

        private static void Create(LogicAdministration logicAdd, int type)
        {
            switch (type)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Brand name (string)");
                        string brandName = Console.ReadLine();
                        Console.WriteLine("CEO Name (string)");
                        string CEOname = Console.ReadLine();
                        Console.WriteLine("Factories number (int)");
                        int factories = int.Parse(Console.ReadLine());
                        Console.WriteLine("Headquarter (string)");
                        string Headquarter = Console.ReadLine();
                        Console.WriteLine("Country Name (string)");
                        string CountryName = Console.ReadLine();
                        Brand newBrand = new Brand() { Name = brandName, CEOName = CEOname, Factories = factories, Headquarter = Headquarter, CountryName = CountryName };
                        logicAdd.CrateNewBrand(newBrand);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Invalid format");
                        Console.ReadKey();
                    }

                    break;

                case 2:
                    try
                    {
                        Console.WriteLine("Number of Brand (1-5) (int)");
                        int FK = int.Parse(Console.ReadLine());
                        Console.WriteLine("Tire price (int)");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Tire Width (int)");
                        int newWidth = int.Parse(Console.ReadLine());
                        Console.WriteLine("Aspecratio number (int)");
                        int newAspectRatio = int.Parse(Console.ReadLine());
                        Console.WriteLine("Diameter (int)");
                        int newDiameter = int.Parse(Console.ReadLine());
                        Console.WriteLine("Tire Name (string)");
                        string newTireName = Console.ReadLine();
                        Tire newTire = new Tire() { BrandID = FK, Price = price, Width = newWidth, AspectRatio = newAspectRatio, Diameter = newDiameter, TireName = newTireName };
                        logicAdd.CrateNewTire(newTire);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Invalid format");
                        Console.ReadKey();
                    }

                    break;
                case 3:
                    try
                    {
                        Console.WriteLine("Number of Brand (1-5) (int)");
                        int FK2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("DOT number (int)");
                        int newDOTNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Production Country Name (string)");
                        string newProductionCountryName = Console.ReadLine();
                        Console.WriteLine("Production Week (int)");
                        int newProductionWeek = int.Parse(Console.ReadLine());
                        Console.WriteLine("Production Year (int)");
                        int newProductionYear = int.Parse(Console.ReadLine());
                        Console.WriteLine("Load index (int)");
                        int newLoadRating = int.Parse(Console.ReadLine());
                        Console.WriteLine("Speed Rating");
                        string newSpeedRating = Console.ReadLine();
                        TireSpecification newtireSpecification = new TireSpecification() { TireID = FK2, DOTNumber = newDOTNumber, ProductionCountryName = newProductionCountryName, ProductionWeek = newProductionWeek, ProductionYear = newProductionYear, LoadIndex = newLoadRating, SpeedRating = newSpeedRating };
                        logicAdd.CrateNewTireSpecification(newtireSpecification);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Invalid format");
                        Console.ReadKey();
                    }

                    break;
            }
        }

        private static void ListAllTire(TireShopLogic logic)
        {
            Console.WriteLine("\n:: TIRES :: \n");
            logic.GetAllTires()
                .ToList()
                .ForEach(x => Console.WriteLine(x.TireName));
            Console.ReadLine();
        }

        private static void ListAllBrands(TireShopLogic logic)
        {
            Console.WriteLine("\n:: Brands :: \n");
            logic.GetAllBrands()
                .ToList()
                .ForEach(x => Console.WriteLine(x.Name));
            Console.ReadLine();
        }

        private static void ListAllTireSpecifications(TireShopLogic logic)
        {
            Console.WriteLine("\n:: TireSpecifications :: \n");
            logic.GetAllTireSpecifications()
                .ToList()
                .ForEach(x => Console.WriteLine(x.Tire));
            Console.ReadLine();
        }

        private static void GetTireById(TireShopLogic logic)
        {
            Console.WriteLine("ENTER ID HERE: ");
            int id = int.Parse(Console.ReadLine());

            var q = logic.GetTireById(id);

            Console.WriteLine("\n:: SELECTED TIRE :: \n");
            Console.WriteLine(q);

            Console.ReadLine();
        }

        private static void GetBrandById(TireShopLogic logic)
        {
            Console.WriteLine("ENTER ID HERE: ");
            int id = int.Parse(Console.ReadLine());

            var q = logic.GetBrandById(id);

            Console.WriteLine("\n:: SELECTED Brand :: \n");
            Console.WriteLine(q);

            Console.ReadLine();
        }

        private static void GetTireSpecificationById(TireShopLogic logic)
        {
            Console.WriteLine("ENTER ID HERE: ");
            int id = int.Parse(Console.ReadLine());

            var q = logic.GetTireSpecificationById(id);

            Console.WriteLine("\n:: SELECTED Tire :: \n");
            Console.WriteLine(q);

            Console.ReadLine();
        }

        //private static void ChangePrice(TireShopLogic logic)
        //{
        //    Console.Write("ENTER ID HERE: ");
        //    int id = int.Parse(Console.ReadLine());

        //    Console.Write("ENTER NEW PRICE HERE: ");
        //    int newPrice = int.Parse(Console.ReadLine());

        //    logic.ChangeTirePrice(id, newPrice);

        //    var q = logic.GetTireById(id);

        //    Console.WriteLine("\n:: NEW PRICE ::\n");
        //    Console.WriteLine(q.Price);

        //    Console.ReadLine();
        //}

        //private static void ChangeBrandCEO(LogicAdministration logicUpdate)
        //{
        //    Console.Write("ENTER ID HERE: ");
        //    int id = int.Parse(Console.ReadLine());

        //    Console.Write("ENTER NEW CEO HERE: ");
        //    string newCEO = Console.ReadLine();

        //    logicUpdate.UpdateBrandCEO(id, newCEO);

        //    var q = logic.GetBrandById(id);

        //    Console.WriteLine("\n:: NEW CEO ::\n");
        //    Console.WriteLine(q.CEOName);

        //    Console.ReadLine();
        //}

        //private static void ChangeSpeedRating(LogicAdministration logicUpdate)
        //{
        //    Console.Write("ENTER ID HERE: ");
        //    int id = int.Parse(Console.ReadLine());

        //    Console.Write("ENTER NEW SPEED RATING HERE: ");
        //    string newCEO = Console.ReadLine();

        //    logicUpdate.UpdateBrandCEO(id, newCEO);

        //    var q = logic.GetTireSpecificationById(id);

        //    Console.WriteLine("\n:: NEW SPEED RATING ::\n");
        //    Console.WriteLine(q.SpeedRating);

        //    Console.ReadLine();
        //}

        private static void GetBrandAVG(TireShopLogic logic)
        {
            Console.WriteLine("Brand AVG-s");
            IList<AvarageResult> a = logic.BrandAvarages();
            foreach (var item in a)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void GetBrandAVGASYNC(TireShopLogic logic)
        {
            Console.WriteLine("Brand AVG-s");
            IList<AvarageResult> a = logic.BrandAvarages();
            var b = logic.BrandAvaragesAsync();
            foreach (var item in b.Result)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void MadeOfPLaceSame(TireShopLogic logic)
        {
            Console.WriteLine("Enter Brand name here: ");
            string brandName = Console.ReadLine();
            Console.WriteLine("Enter Tire name here: ");
            string tireName = Console.ReadLine();
            IList<HQMadeofPlace> a = logic.HQMadeofPlaces(brandName, tireName);
            HQMadeofPlace b = new HQMadeofPlace();

            foreach (var item in a)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        private static void MadeOfPLaceSameAsync(TireShopLogic logic)
        {
            Console.WriteLine("Enter Brand name here: ");
            string brandName = Console.ReadLine();
            Console.WriteLine("Enter Tire name here: ");
            string tireName = Console.ReadLine();
            var a = logic.HQMadeofPlacesAsync(brandName, tireName);
            HQMadeofPlace b = new HQMadeofPlace();

            foreach (var item in a.Result)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        private static void TireRecommendation(TireShopLogic logic)
        {
            Console.WriteLine("Enter your budget here: ");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tire width's here: ");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tire aspect ratio's here: ");
            int aspectRatio = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tire diameter's here: ");
            int diameter = int.Parse(Console.ReadLine());
            IList<TireRecommendation> a = logic.TireRecommendations(maxPrice, width, aspectRatio, diameter);
            foreach (var item in a)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        private static void TireRecommendationASYNC(TireShopLogic logic)
        {
            Console.WriteLine("Enter your budget here: ");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tire width's here: ");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tire aspect ratio's here: ");
            int aspectRatio = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tire diameter's here: ");
            int diameter = int.Parse(Console.ReadLine());
            var a = logic.TireRecommendationsAsync(maxPrice, width, aspectRatio, diameter);
            foreach (var item in a.Result)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
    }
}
