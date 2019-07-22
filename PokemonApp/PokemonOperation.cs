using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HtmlAgilityPack;
using System.Net.Http;

namespace PokemonApp
{
    public static class PokemonOperation
    {
        public static string GetPokemonName(HtmlNode pokemonNode, int index)
        {
            var getName = pokemonNode.SelectNodes("//a[@class='ent-name']")[index];// .ElementAtOrDefault(counter);
            return getName.InnerText;
        }
    }
}
