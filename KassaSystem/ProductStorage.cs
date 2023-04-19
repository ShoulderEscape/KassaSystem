using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KassaSystem
{
    public class ProductStorage
    {
        private string filename;
        public ProductStorage(string filename)
        {
            this.filename = filename;
        }
        public void Save(List<Product> products)
        {
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filename, json);



        }
        public List<Product> GetProducts()
        {
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<List<Product>>(json);
            
        }
        public bool FileExists()
        {
            if(File.Exists(filename)) return true;
            return false;
        }
    }
}
