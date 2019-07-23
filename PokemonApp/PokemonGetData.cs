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

        public static List<HtmlNode> productListItems()
        {
            HtmlDocument pokemonPage = new HtmlDocument();
            pokemonPage.LoadHtml(Properties.Resources.page);

            var producsHtml = pokemonPage.DocumentNode.Descendants("div")
               .Where(node => node.GetAttributeValue("class", "")
               .Equals("infocard-list infocard-list-pkmn-lg")).ToList();

            var pokemonListItems = producsHtml[0].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("infocard")).ToList();

            return pokemonListItems;
        }

        public static List<Pokemon> seasonOne()
        {

            List<Pokemon> seasonOne = new List<Pokemon>();
            var productListItems = PokemonGetData.productListItems();
            string name;
            string img;
            string type;


            foreach (var pokemon in productListItems)
            {
                var index = Array.IndexOf(productListItems.ToArray(), pokemon);

                name = PokemonGetData.GetPokemonName(pokemon, index);
                img = PokemonGetData.GetPokemonImage(pokemon, index);
                type = PokemonGetData.GetPokemonType(pokemon, index);

                //------------------------------------------------------------------------------------------------------
                //                         Adding Pokemon Object to the Loop
                //------------------------------------------------------------------------------------------------------
                Pokemon poke = new Pokemon(name, img, type);
                //Pokemon poke = new Pokemon(img);
                seasonOne.Add(poke);
                //------------------------------------------------------------------------------------------------------
            }

            return seasonOne;
        }
    }
}
