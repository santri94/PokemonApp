using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp
{
     public class Pokemon
    {
        public int number { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string type { get; set; }

        public Pokemon(int number, string name, string image, string type)
        {
            this.number = number;
            this.name = name;
            this.image = image;
            this.type = type;
        }
        public Pokemon(int number, string image)
        {
            this.number = number;
            this.image = image;
        }
    }
}
