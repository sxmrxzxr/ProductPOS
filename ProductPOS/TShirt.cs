using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class TShirt : Apparel
    {
        private string size;

        public TShirt(string type, string id, string desc, double price, int qty, string color, string manufacturer, string material, string size) : base(type, id, desc, price, qty, color, manufacturer, material)
        {
            this.size = size;
        }

        public string Size
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

        public override string GetDisplayText(string separator)
        {
            return base.GetDisplayText(separator) + separator + size;
        }
    }
}
