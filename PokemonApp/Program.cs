using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp
{
    public class Program
    {
        public List<HtmlNode> productListItems;

        public Program()
        {
            GetHtmlAsync();
            Console.WriteLine("Constructor Called!!");
        }
        

        public void CalledSecondWindow()
        {
            PokemonWindow SecondWindow = new PokemonWindow(productListItems);
            SecondWindow.Show();
            SecondWindow.Test();
        }

        public async void GetHtmlAsync()
        {
            var url = "https://pokemondb.net/pokedex/national";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var producsHtml = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("infocard-list infocard-list-pkmn-lg")).ToList();

            productListItems = producsHtml[0].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("infocard")).ToList();



            /*
            int counter = 0;
            string href;
            foreach (var productListItem in productListItems)
            {

                Console.WriteLine(productListItem.InnerText);
                var link = productListItem.SelectNodes("//span[@data-src]").ElementAtOrDefault(counter
                    );
                href = link.Attributes["data-src"].Value;
                Console.WriteLine($"Image : {href} ");
                counter++;

            }
            */




            //Console.WriteLine();


        }

    }
}
