using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassaSystem
{
    public class Generator
    {
        public string generateID(List<Kund> kunder)
        {
            
            var faker = new Faker();
            string Return;
            do
            {
                Return = faker.Commerce.Ean13();
            } while (kunder.Any(kund => kund.getID() == Return));
            return Return;
        }
        public List<Product> generateProducts(int input)
        {
            var faker = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(product => product.name, faker => faker.Commerce.ProductName())
                .RuleFor(product => product.cost, faker => faker.Commerce.Price())
                .RuleFor(product => product.id, faker => faker.Random.Int(0, input * 10).ToString())
                .RuleFor(product => product.costType, faker=>faker.Random.Float().ToString());
                
            List<Product> products = new List<Product>();
            do
            {
                Random random = new Random();

                products = faker.Generate(input);
                foreach(Product product in products)
                {
                    if (float.Parse(product.costType) > 0.5)
                        product.costType = "per kilo";
                    else product.costType = "per piece";
                }

            } while (regenerate(products));
            return products;
        }
        public bool regenerate(List<Product> products)
        {
            return products.GroupBy(product =>
                product.name).Select(firstProduct =>
                firstProduct.First()).Count() != products.Count()
                ||
                products.GroupBy(product => product.id).Select(firstProduct =>
                firstProduct.First()).Count() != products.Count();
        }
    }
}
