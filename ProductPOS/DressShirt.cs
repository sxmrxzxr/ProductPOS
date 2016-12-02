using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class DressShirt : Apparel
    {
        private int neck;
        private int sleeve;

        public DressShirt(string type, string id, string desc, double price, int qty, string color, string manufacturer, string material, int neck, int sleeve) : base(type, id, desc, price, qty, color, manufacturer, material)
        {
            this.neck = neck;
            this.sleeve = sleeve;
        }

        public int Neck
        {
            get
            {
                return neck;
            }
            set
            {
                neck = value;
            }
        }

        public int Sleeve
        {
            get
            {
                return sleeve;
            }
            set
            {
                sleeve = value;
            }
        }

        public override string GetDisplayText(string separator)
        {
            return base.GetDisplayText(separator) + separator + neck + separator + sleeve;
        }
    }
}
