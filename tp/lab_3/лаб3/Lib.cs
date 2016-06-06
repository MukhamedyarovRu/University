using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб3
{
    public class Lib
    {

        public decimal Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public DateTime Year { get; set; }
        public string Condition { get; set; }

        public Lib(decimal Id, string Brand, string Color, DateTime Year, string Condition)
        {
            
            this.Id = Id;
            this.Brand = Brand;
            this.Color = Color;
            this.Year = Year;
            this.Condition = Condition;
        }

        public Lib() { }
    }
}
