using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KassaSystem;

namespace KassasystemTest
{
    [TestClass]
    public class GeneratorTest
    {
        private readonly Generator sut = new Generator();

        [TestMethod]
        public void regenerate_should_be_false_when_inputing_a_list_that_has_distinct_products()
        {
            List<Product> products = new List<Product>();
            var product1 = new Product();
            product1.cost = "10";
            product1.name = "Name";
            product1.id = "1";
            var product2 = new Product();
            product2.cost = "11";
            product2.name = "Name2";
            product2.id = "2";
            products.Add(product1);
            products.Add(product2);

            Assert.IsFalse(sut.regenerate(products));

        }
        [TestMethod]
        public void regenerate_should_be_true_when_inputing_a_list_that_does_not_have_distinct_product_names()
        {
            List<Product> products = new List<Product>();
            var product1 = new Product();
            product1.cost = "10";
            product1.name = "Name";
            product1.id = "1";
            var product2 = new Product();
            product2.cost = "11";
            product2.name = "Name";
            product2.id = "2";
            products.Add(product1);
            products.Add(product2);

            Assert.IsTrue(sut.regenerate(products));

        }
        [TestMethod]
        public void regenerate_should_be_true_when_inputing_a_list_that_does_not_have_distinct_product_ids()
        {
            List<Product> products = new List<Product>();
            var product1 = new Product();
            product1.cost = "10";
            product1.name = "Name";
            product1.id = "1";
            var product2 = new Product();
            product2.cost = "11";
            product2.name = "Name";
            product2.id = "1";
            products.Add(product1);
            products.Add(product2);

            Assert.IsTrue(sut.regenerate(products));

        }




    }
}
