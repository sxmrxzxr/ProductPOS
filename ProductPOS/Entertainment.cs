using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class Entertainment : Disk
    {
        private TimeSpan runTime;

        public Entertainment(string type, string id, string desc, double price, int qty, DateTime releaseDate, int numDisks, int size, string typeDisk, TimeSpan runTime) : base(type, id, desc, price, qty, releaseDate, numDisks, size, typeDisk)
        {
            this.runTime = runTime;
        }

        public TimeSpan RunTime
        {
            get
            {
                return runTime;
            }
            set
            {
                runTime = value;
            }
        }

        public override string GetDisplayText(string separator)
        {
            return base.GetDisplayText(separator) + separator + runTime.ToString();
        }
    }
}
