using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class Product
    {
        private string desc;
        private string id;
        private double price;
        private int qty;
        private string type;

        public Product()
        {

        }

        public Product(string type, string id, string desc, double price, int qty)
        {            
            this.type = type;
            this.id = id;
            this.desc = desc;
            this.price = price;
            this.qty = qty;            
        }

        public string Desc
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
            }
        }

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return qty;
            }
            set
            {
                qty = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public virtual string GetDisplayText(string separator)
        {
            return desc + separator + id + separator + price + separator + qty + separator + type;
        }

        public string ToCSV()
        {
            return GetDisplayText(",");
        }

        public override string ToString()
        {
            return GetDisplayText("\r\n");
        }
    }
}
