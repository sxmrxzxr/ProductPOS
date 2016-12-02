using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class Software : Disk
    {
        private string typeSoft;
        /*
        public Software()
        {

        }*/

        public Software(string type, string id, string desc, double price, int qty, DateTime releaseDate, int numDisks, int size, string typeDisk, string typeSoft) : base(type, id, desc, price, qty, releaseDate, numDisks, size, typeDisk)
        {
            this.typeSoft = typeSoft;
        }

        public string TypeSoft
        {
            get
            {
                return typeSoft;
            }
            set
            {
                typeSoft = value;
            }
        }

        public override string GetDisplayText(string separator)
        {
            return base.GetDisplayText(separator) + separator + typeSoft;
        }
    }
}
