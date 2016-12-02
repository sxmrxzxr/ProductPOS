using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class Pants : Apparel
    {
        private int inseam;
        private int waist;

        public Pants(string type, string id, string desc, double price, int qty, string color, string manufacturer, string material, int inseam, int waist) : base(type, id, desc, price, qty, color, manufacturer, material)
        {
            this.inseam = inseam;
            this.waist = waist;
        }

        public int Inseam
        {
            get
            {
                return inseam;
            }
            set
            {
                inseam = value;
            }
        }

        public int Waist
        {
            get
            {
                return waist;
            }
            set
            {
                waist = value;
            }
        }

        public override string GetDisplayText(string separator)
        {
            return base.GetDisplayText(separator) + separator + inseam + separator + waist;
        }
    }
}
