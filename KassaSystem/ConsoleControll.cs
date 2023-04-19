using Bogus;
using Bogus.Extensions.Italy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KassaSystem
{
    internal class ConsoleControll
    {
        private List<Kund> kunder = new List<Kund>();

        public void menu(Generator generator, List<Product> productList)
        {
            StorageTxt storage = new StorageTxt();

            while (true)
            {
                Console.WriteLine("1: Ny kund\n2: Avsluta");


                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var kund = new Kund();
                        kund.setID(generator.generateID(kunder));
                        string receipt = Buying(productList);
                        storage.save(receipt);
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        var validator=new Validator(input);
                        validator.MainMenu();
                        validator.Errors.ForEach(error => Console.WriteLine(error));
                        break;
                }
            }
        }
        private List<Product> _products = new List<Product>();
        public string Buying(List<Product> products)
        {
            ReceiptCenter receipts = new ReceiptCenter();

            _products = products;
            WriteOutInventory();
            
            Console.WriteLine("What do you want to buy?\n\t<productid amount>");
            string input = Console.ReadLine();
            string[] inputs = input.Split(' ');
            if (int.TryParse(inputs[0], out int value1) && int.TryParse(inputs[1], out int value2) &&
                _products.Any(product => product.id == inputs[0]))
            {
                receipts.AddToReceipt(value1, value2, products);
                Console.WriteLine("Do you want to buy more products (y/n)?");
                while (true)
                {
                    string answer= Console.ReadLine();
                    
                    switch (answer.ToLower())
                    {
                        case "y":
                            return Buying(products);
                        case "n":
                            return receipts.WriteOutReceipt();
                        default:
                            var validatorBuyMore = new Validator(input);
                            validatorBuyMore.MainMenu();
                            validatorBuyMore.Errors.ForEach(error => Console.WriteLine(error));
                            break;

                    }

                    
                    
                }
            }
            var validator = new Validator(input);
            validator.MainMenu();
            validator.Errors.ForEach(error => Console.WriteLine(error));
            return Buying(products);
        }
        public void WriteOutInventory()
        {
            int nameWidth = _products.Max(p => p.name.Length);
            int idWidth = _products.Max(p => p.id.Length);
            int costWidth = _products.Max(p => (p.cost.Length+" "+p.costType).Length);
            for(int i=0; i < nameWidth + idWidth + costWidth +9; i++) 
            {
                Console.Write("-");
            }
            Console.WriteLine();
            string formatString = "{0,-" + nameWidth + "}  {1,-" + idWidth + "}  {2,-" + costWidth + "}";
            Console.WriteLine(formatString, "Name", "ID", "Cost");

            foreach (Product product in _products)
            {
                

                // output the list of objects with aligned columns
                Console.WriteLine(formatString, product.name, product.id, product.cost+ " "+product.costType);

                Console.WriteLine();
            }
            for (int i = 0; i < nameWidth + idWidth + costWidth + 9; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}
