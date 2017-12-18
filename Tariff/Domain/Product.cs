using System;

namespace Tariff.Domain
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public Func<decimal, decimal> CalcAnnualCostFromConsumption { get; set; }
    }
}
