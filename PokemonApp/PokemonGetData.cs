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

        public static string GetPokemonImage(HtmlNode pokemonNode, int index)
        {
            var getImage = pokemonNode.SelectNodes("//span[@data-src]")[index];// .ElementAtOrDefault(counter);
            return getImage.Attributes["data-src"].Value;
        }

        public static string GetPokemonType(HtmlNode pokemonNode, int index)
        {
            var getType = pokemonNode.SelectNodes("//small[2]//a[1]")[index];// .ElementAtOrDefault(counter);
            return getType.InnerText;
        }
    }
}
