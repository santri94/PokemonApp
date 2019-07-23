using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp
{
    public static class PokemonGetData
    {
        public static string GetPokemonName(HtmlNode pokemonNode, int index)
        {
            var getName = pokemonNode.SelectNodes("//a[@class='ent-name']")[index];// .ElementAtOrDefault(counter);
            return getName.InnerText;
        }
    }
}
