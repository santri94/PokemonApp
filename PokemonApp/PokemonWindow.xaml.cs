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
        public List<HtmlNode> productListItems;
        public PokemonWindow()
        {
            InitializeComponent();
            GetHtmlAsync();
            //AddPokemons();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int counter = 0;
            string href;
            int row = 0; // Increment this every time u add a pokemon
            int col = 1; // Maybe dont have to Increment this 



            //--------------------------------------------------------------------------------------------------------------------------------

            /*
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(href));
            image.Height = 100;
            image.Width = 100;
            image.Margin = new Thickness(47, 25, 0, 0);
            image.Visibility = System.Windows.Visibility.Visible;
            image.VerticalAlignment = 0;
            image.Opacity = 1.0;
            */

            ScrollViewer viewer = new ScrollViewer();
            //viewer.HorizontalScrollBarVisibility = ScrollBarVisibility[1];
            
            foreach (var pokemon in productListItems)
            {
                var link = pokemon.SelectNodes("//span[@data-src]").ElementAtOrDefault(counter);
                href = link.Attributes["data-src"].Value;
                RowDefinition x = new RowDefinition();
                Grid.RowDefinitions.Add(x);
                x.Height = new GridLength(150);
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(href));
                image.Height = 100;
                image.Width = 100;
                Grid.SetRow(image, row);
                Grid.SetColumn(image, col);
                Grid.Children.Add(image);
                counter++;
                row++;
            }

            //RowDefinition x = new RowDefinition();
            //GridLength y = new GridLength(150);
            //Grid.RowDefinitions.Add(new RowDefinition());
            

            /*
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(href));
            image.Height = 100;
            image.Width = 100;
            Grid.SetRow(image, row);
            Grid.SetColumn(image, col);
            Grid.Children.Add(image);
            */




            //---------------------------------------------------------------------------------------------------------------------------------

            //MessageBox.Show($" bulbasaur Image : {href}");


            //MessageBox.Show(productListItems[0].InnerHtml);

            /*
            var link = productListItems[counter].SelectNodes("//span[@data-src]").ElementAtOrDefault(counter);
            href = link.Attributes["data-src"].Value;
            MessageBox.Show($" bulbasaur Image : {href}");

            SecondImage.Source = new BitmapImage(new Uri(href));
            */

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

        }

    }
}
