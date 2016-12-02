using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class Movie : Entertainment
    {
        private string director;
        private string producer;

        public Movie(string type, string id, string desc, double price, int qty, DateTime releaseDate, int numDisks, int size, string typeDisk, TimeSpan runTime, string director, string producer) : base(type, id, desc, price, qty, releaseDate, numDisks, size, typeDisk, runTime)
        {
            this.director = director;
            this.producer = producer;
        }

        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                director = value;
            }
        }

        public string Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
            }
        }

        public override string GetDisplayText(string separator)
        {
            return base.GetDisplayText(separator) + separator + director + separator + producer;
        }
    }
}
