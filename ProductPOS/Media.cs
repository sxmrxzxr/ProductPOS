using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class Media : Product
    {
        private DateTime releaseDate;

        public Media(string type, string id, string desc, double price, int qty, DateTime releaseDate) : base(type, id, desc, price, qty)
        {
            this.releaseDate = releaseDate;
        }

        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }
            set
            {
                releaseDate = value;
            }
        }

        public override string GetDisplayText(string separator)
        {
            return base.GetDisplayText(separator) + separator + releaseDate.ToShortDateString();
        }
    }
}
