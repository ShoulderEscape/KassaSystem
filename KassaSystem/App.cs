using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace KassaSystem
{
    public class App
    {
        
        private ConsoleControll control= new ConsoleControll();
        public void Run()
        {
            string filename = "products.JSON";

            ProductStorage productStorage = new ProductStorage(filename);
            var productList = new List<Product>();
            var generator = new Generator();

            if (!productStorage.FileExists())
            {
                productList.AddRange(generator.generateProducts(10));
                productStorage.Save(productList);
            }
            else
            {
                productList = productStorage.GetProducts();
            }
            control.menu(generator, productList);




        }
    }
}