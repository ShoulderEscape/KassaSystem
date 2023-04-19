using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KassaSystem
{
    internal class StorageTxt :Storage
    {
        public StorageTxt() { }
        public void save(string str)
        {
            DateTime now = DateTime.Now;
            
            string month=""+now.Month;
            string day=""+now.Day;
            if (month.Length == 1) month = 0 + month;
            if(day.Length == 1) day = 0 + day;
            string filename = $"RECEIPT_{now.Year}{month}{day}.txt";

            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            File.AppendAllText(filename, str);
        }
        

    }
}