using System;
using System.Collections.Generic;
using System.Text;

namespace Tariff.Domain
{
    public class ProductCost
    {
        public string Name;
        public decimal AnnualCost;

        public ProductCost(string name, decimal annualCost)
        {
            Name = name;
            AnnualCost = annualCost;
        }
    }
}
