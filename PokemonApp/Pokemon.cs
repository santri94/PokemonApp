using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp
{
     public class Pokemon
    {
        public string name { get; set; }
        public string image { get; set; }
        public string type { get; set; }

        public Pokemon(string name, string image, string type)
        {
            this.name = name;
            this.image = image;
            this.type = type;
        }
        public Pokemon(string image)
        {
            this.image = image;
        }
    }
}
