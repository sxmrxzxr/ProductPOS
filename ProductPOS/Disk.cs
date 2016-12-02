using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class Disk : Media
    {
        private int numDisks;
        private int size;
        private string typeDisk;

        /*
        public Disk()
        {

        }*/

        public Disk(string type, string id, string desc, double price, int qty, DateTime releaseDate, int numDisks, int size, string typeDisk) : base(type, id, desc, price, qty, releaseDate)
        {
            this.numDisks = numDisks;
            this.size = size;
            this.typeDisk = typeDisk;
        }

        public int NumDisks
        {
            get
            {
                return numDisks;
            }
            set
            {
                numDisks = value;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public string TypeDisk
        {
            get
            {
                return typeDisk;
            }
            set
            {
                typeDisk = value;
            }
        }

        public override string GetDisplayText(string separator)
        {
            return base.GetDisplayText(separator) + separator + numDisks + separator + size + separator + typeDisk;
        }
    }
}
