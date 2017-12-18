using System;
using System.Collections.Generic;
using Tariff.Domain;
using Newtonsoft.Json;

namespace Tariff.Example
{
    class Program
    {
        private static void Dump(IEnumerable<ProductCost> item)
        {
            Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
        }

        static void Main(string[] args)
        {
            var comparison = new ProdductComparison(new List<Product>() {
                new Product() {
                    Name = "basic electricity tariff",
                    CalcAnnualCostFromConsumption = 
                        c => 12 * 5 + c * 0.22m
                },
                new Product() {
                    Name = "Packaged tariff",
                    CalcAnnualCostFromConsumption =
                        c => 800 + ((c > 4000) ? (c - 4000) * 0.3m : 0)
                },
            });
            
            Dump(comparison.Evaluate(3500));
            Dump(comparison.Evaluate(4500));
            Dump(comparison.Evaluate(6000));

            
        }
    }
}
