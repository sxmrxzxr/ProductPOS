using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class Book : Media
    {
        private string author;
        private int numPages;
        private string publisher;

        /*
        public Book()
        {

        }*/

        public Book(string type, string id, string desc, double price, int qty, DateTime releaseDate, string author, int numPages, string publisher) : base(type, id, desc, price, qty, releaseDate)
        {
            this.author = author;
            this.numPages = numPages;
            this.publisher = publisher;
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }

        public int NumPages
        {
            get
            {
                return numPages;
            }
            set
            {
                numPages = value;
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }
            set
            {
                publisher = value;
            }
        }

        public override string GetDisplayText(string separator)
        {
            return base.GetDisplayText(separator) + separator + author + separator + numPages + separator + publisher;
        }
    }
}
