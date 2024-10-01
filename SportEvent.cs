using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paralimpia
{
    internal class SportEvent
    {
        public int Year { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Dictionary<string, int> Medals { get; set; }

        public SportEvent(string row)
        {
            var pieces = row.Split(';');
            Year = int.Parse(pieces[0]);
            Country = pieces[1];
            City = pieces[2];
            Medals = new()
            {
                { "gold", int.Parse(pieces[3]) },
                { "silver", int.Parse(pieces[4]) },
                { "bronze", int.Parse(pieces[5]) }
            };
        }

        public override string ToString()
        {
            return
                $"\tÉv: {Year},\n" +
                $"\tOrszág: {Country},\n" +
                $"\tVáros: {City},\n" +
                $"\tEredmények: Arany:{Medals["gold"]}, Ezüst:{Medals["silver"]}, Bronz:{Medals["bronze"]}";
        }
    }
}
