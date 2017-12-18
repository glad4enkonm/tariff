using Xunit;
using Moq;
using Tariff.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Tarif.Test
{
    public class UnitTest
    {
        [Fact]
        public void Check_Product_Comparison_With_One_Product()
        {
            Mock<IProduct> productMock = new Mock<IProduct>();
            productMock.SetupProperty(prod => prod.CalcAnnualCostFromConsumption, cons => cons);
            productMock.SetupProperty(prod => prod.Name, "Test");

            var comparison = new ProdductComparison(new List<IProduct>() { productMock.Object});
            var compResult = comparison.Evaluate(100);         

            Assert.Equal(compResult.First().AnnualCost, 100);
            Assert.Equal(compResult.First().Name, "Test");
            Assert.Equal(compResult.Count(), 1);
        }

        [Fact]
        public void Check_Product_Comparison_Returns_Sorted_Result_Two_Products()
        {
            Mock<IProduct> productAMock = new Mock<IProduct>();
            productAMock.SetupProperty(prod => prod.CalcAnnualCostFromConsumption, cons => cons);
            productAMock.SetupProperty(prod => prod.Name, "Test");

            Mock<IProduct> productBMock = new Mock<IProduct>();
            productBMock.SetupProperty(prod => prod.CalcAnnualCostFromConsumption, cons => cons * 2);
            productBMock.SetupProperty(prod => prod.Name, "Test");

            var comparison = new ProdductComparison(new List<IProduct>() { productAMock.Object, productBMock.Object });
            var compResult = comparison.Evaluate(100);

            Assert.Equal(compResult.First().AnnualCost, 100);
            Assert.Equal(compResult.Last().AnnualCost, 200);

            Assert.Equal(compResult.First().Name, "Test");
            Assert.Equal(compResult.Last().Name, "Test");

            Assert.Equal(compResult.Count(), 2);
        }

        [Fact]
        public void Check_Product_Comparison_Returns_Sorted_Result_Many_Products()
        {
            const int productsAmount = 100;

            var prodList = new List<IProduct>(
                Enumerable.Range(1, productsAmount).Select(i =>
                {
                    var productMock = new Mock<IProduct>();
                    productMock.SetupProperty(prod => 
                        prod.CalcAnnualCostFromConsumption, cons => cons * i);
                    productMock.SetupProperty(prod => prod.Name, "Test");
                    return productMock.Object;
                })
            );

            var comparison = new ProdductComparison(prodList);
            var compResult = comparison.Evaluate(1);

            Assert.Equal(compResult.Select(pc => pc.AnnualCost), 
                Enumerable.Range(1, productsAmount).Select(i => (decimal) i));            
            
        }

    }
}
