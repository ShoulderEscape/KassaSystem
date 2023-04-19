using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KassaSystem
{
    public class Validator
    {
        private string _input;
        public Validator(string input) { }
        public enum Error
        {
            Not_Integer,
            Too_Long,
            Too_Few_Inputs,
            Too_Many_Inputs,
            Not_Letter,
            Not_Y_or_N

        }
        public List<Error> Errors { get; set; } = new List<Error>();
        public void MainMenu()
        {
            MainAndShopping();
            MainAndBuyMore();
        
        }
        public void ShoppingCart()
        {
            MainAndShopping();
            if (OneInput()) Errors.Add(Error.Too_Few_Inputs);
            else if (!TwoInputs()) Errors.Add(Error.Too_Many_Inputs);
        }
        public void BuyMore()
        {
            MainAndBuyMore();
            if (NotLetter()) Errors.Add(Error.Not_Letter);
            if (NotYOrN()) Errors.Add(Error.Not_Y_or_N);
            

        }
        public void MainAndBuyMore()
        {
            if (TooLong(1)) Errors.Add(Error.Too_Long);
        }
        private void MainAndShopping()
        {
            
            if (NotInt()) Errors.Add(Error.Not_Integer);


        }
        private bool NotLetter(){ return !_input.All(Char.IsLetter); }
        private bool NotInt() { return !_input.All(Char.IsDigit); }

        private bool TooLong(int length) { return _input.Length <= length; }
        private bool OneInput() { return !_input.Contains(' '); }
        private bool TwoInputs() { return _input.Count(x=> x==' ')==1; }
        private bool NotYOrN() { return _input != "n" || _input != "y"; }
        
        
    }
}
