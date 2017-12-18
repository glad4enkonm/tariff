using System;
using System.Collections.Generic;
using System.Linq;

namespace Tariff.Domain
{
    public class ProdductComparison
    {
        private List<IProduct> _products;

        public ProdductComparison(IEnumerable<IProduct> products)
        {
            _products = products.ToList();
        }

        public IEnumerable<ProductCost> Evaluate(decimal consumption)
        {
            return _products.Select(p => 
                new ProductCost(p.Name, p.CalcAnnualCostFromConsumption(consumption))
            ).OrderBy(pc => pc.AnnualCost);
        }
    }
}
