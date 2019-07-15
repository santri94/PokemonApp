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
    /// <summary>
    /// Interaction logic for PokemonWindow.xaml
    /// </summary>
    public partial class PokemonWindow : Window
    {
        public List<HtmlNode> productListItems = new List<HtmlNode>();
        public List<Pokemon> seasonOne = new List<Pokemon>();
        public PokemonWindow()
        {
            InitializeComponent();
            GetHtmlAsync();
            //LoadPokemons();
        }

        private void LoadPokemons()
        {

            int counter = 0;
            string name;
            string img;
            string type;
            int row = 0; // Increment this every time u add a pokemon
            int col = 1; // Maybe dont have to Increment this 

            
            foreach (var pokemon in productListItems)
            {

                var getName = pokemon.SelectNodes("//span[2]//a[1][@class='ent-name']").ElementAtOrDefault(counter);
                name = getName.InnerText;

                var link = pokemon.SelectNodes("//span[@data-src]").ElementAtOrDefault(counter);
                img = link.Attributes["data-src"].Value;

                var getType = pokemon.SelectNodes("//span[2]//small[2]//a[1]").ElementAtOrDefault(counter);
                type = getType.InnerText;



                //------------------------------------------------------------------------------------------------------
                //                         Adding Pokemon Object to the Loop
                //------------------------------------------------------------------------------------------------------
                Pokemon poke = new Pokemon(name, img, type);
                seasonOne.Add(poke);
                //------------------------------------------------------------------------------------------------------
                counter++;
            }
            foreach (var item in seasonOne)
            {
                RowDefinition x = new RowDefinition();
                Grid.RowDefinitions.Add(x);
                x.Height = new GridLength(150);
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(item.image));
                image.Height = 100;
                image.Width = 100;
                Grid.SetRow(image, row);
                Grid.SetColumn(image, col);
                Grid.Children.Add(image);
                row++;
            }

            this.Show();
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

            LoadPokemons();

        }

    }
}
