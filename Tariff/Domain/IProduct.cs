using System;
using System.Collections.Generic;
using System.Text;

namespace Tariff.Domain
{
    public interface IProduct
    {
        string Name { get; set; }
        Func<decimal, decimal> CalcAnnualCostFromConsumption { get; set; }    
    }
}
