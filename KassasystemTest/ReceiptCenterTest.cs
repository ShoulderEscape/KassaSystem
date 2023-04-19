using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KassaSystem;

namespace KassasystemTest
{
    [TestClass]
    public class ReceiptCenterTest
    {
        private readonly ReceiptCenter sut = new ReceiptCenter();
        [TestMethod]
        public void should_return_correct_receipt_writing()
        {
            int amount = 10;
            int id = 1;
            List<Product> products = new List<Product>();
            Product product = new Product();
            product.cost = "10";
            product.name = "Test";
            product.id = id.ToString();
            sut.AddToReceipt(id, amount, products );
            string shouldReturn = $"{DateTime.Now} {$"\n{amount} {product.name}: {amount * decimal.Parse(product.cost)}"}\nTotal: {amount}\n";
            Assert.AreEqual(shouldReturn, sut.WriteOutReceipt());
        }

    }
}
