using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassaSystem
{
    public class Kund
    {
        private string _id;
        public Kund() { }
        public void setID(string id)
        {
            _id = id;
        }
        public string getID()
        {
            return _id;
        }

    }
}
