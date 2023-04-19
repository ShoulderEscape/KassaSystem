using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KassaSystem
{
    public class ReceiptCenter
    {
        private string receipt;
        private decimal totalcost = 0;
        public ReceiptCenter() 
        {
            receipt = "";
        }


        public void AddToReceipt(int id, int amount, List<Product> products)
        {
            var thisproduct = products.Find(product => product.id == id.ToString());
            var cost = amount * decimal.Parse(thisproduct.cost);
            receipt=receipt+($"\n{amount} {thisproduct.name}: {amount * decimal.Parse(thisproduct.cost)}");
            totalcost += cost;
        }
        public string WriteOutReceipt()
        {
            return $"#\n{DateTime.Now} {receipt}\nTotal: {totalcost}\n";
        }
    }
}
