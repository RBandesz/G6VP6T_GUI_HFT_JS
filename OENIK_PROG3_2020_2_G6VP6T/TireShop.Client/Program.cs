using System;
using TireShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TireShop.Client
{ 
    class Program
    {
        static RestService rest;
        static void Main(string[] args)
        {
           rest = new RestService("http://localhost:55023/", "tireShop");
        }

        static void Create(string entity)
        {
            if (entity == "Tire")
            {
                Console.Write("Enter Tire Name: ");
                string name = Console.ReadLine();
                rest.Post(new Tire() { TireName = name }, "Tire");
            }
        }
        static void List(string entity)
        {
            if (entity == "Tire")
            {
                List<Tire> actors = rest.Get<Tire>("tire");
                foreach (var item in actors)
                {
                    Console.WriteLine(item.TireName + ": " + item.TireSpecifications);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Tire")
            {
                Console.Write("Enter Tire's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Tire one = rest.Get<Tire>(id, "tire");
                Console.Write($"New name [old: {one.TireName}]: ");
                string name = Console.ReadLine();
                one.TireName = name;
                rest.Put(one, "tire");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Tire")
            {
                Console.Write("Enter Tire's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "tire");
            }
        }
    }
}
