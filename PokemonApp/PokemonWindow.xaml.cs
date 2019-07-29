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
    /// 
    /// image : https://www.google.com/search?q=pokemon&safe=strict&biw=1600&bih=757&tbm=isch&source=lnt&tbs=isz:ex,iszw:400,iszh:90#imgrc=1WlSbpprKRo1dM:
    public partial class PokemonWindow : Window
    {
        public List<HtmlNode> productListItems = new List<HtmlNode>();
        public List<Pokemon> seasonOne = new List<Pokemon>();
        LoadWindow loadWindow = new LoadWindow();
        public PokemonWindow()
        {
            InitializeComponent();
            Next();
        }

        public void Next()
        {
            loadWindow.Show();
        }

        public void DisplayWindowWithPokemons()
        {
            productListItems = PokemonGetData.productListItems();
            seasonOne = PokemonGetData.seasonOne();
            PrintPokemons();
            loadWindow.Close();
            this.Show();
            //EmptyGrid();
        }

        public void EmptyGrid()
        {
            var numberOfChildren = Grid.Children.Count;
            var numberOfRows = Grid.RowDefinitions.Count;
            //-----------------------------------------------------------------------------------------------
            //                                  Delete everything  from grid    
            //-----------------------------------------------------------------------------------------------
            if (numberOfRows == 0)
            {
                //Don't do Anything about to start creating colums;
            }
            else
            {
                Grid.Children.RemoveRange(0,numberOfChildren);
                Grid.RowDefinitions.RemoveRange(0, numberOfRows);

            }
            
            //-----------------------------------------------------------------------------------------------
            //MessageBox.Show($"Number of Elements on Grid {numberOfChildren} number of Rows {numberOfRows}");

            
        }

        private void PrintPokemons()
        {
            int row = 0; // Increment this every time u add a pokemon
            int pokemonsCol = 2; // Maybe dont have to Increment this 
            int pokemonInfoCol = 1; // Maybe dont have to Increment this 
            //var seasonOne = PokemonGetData.seasonOne();

            foreach (var item in seasonOne)
            {
                RowDefinition x = new RowDefinition();
                Grid.RowDefinitions.Add(x);
                x.Height = new GridLength(150);
                //-------------------------------------------------------------------------------------------------------
                //                                      Adding Name and Type for Each Pokemon
                //-------------------------------------------------------------------------------------------------------
                TextBlock info = new TextBlock();
                info.Text = $"   {item.name} \n   ({item.type})";
                info.FontSize = 20;
                info.VerticalAlignment = VerticalAlignment.Center;
                info.HorizontalAlignment = HorizontalAlignment.Left;
                info.Foreground = System.Windows.Media.Brushes.OrangeRed;
                info.FontWeight = System.Windows.FontWeights.Bold;
                info.FontStyle = System.Windows.FontStyles.Italic;

                Grid.SetRow(info, row);
                Grid.SetColumn(info, pokemonInfoCol);
                Grid.Children.Add(info);
                //-------------------------------------------------------------------------------------------------------
                //-------------------------------------------------------------------------------------------------------
                //                                      Adding Image     
                //-------------------------------------------------------------------------------------------------------
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(item.image));
                image.Height = 130;
                image.Width = 130;
                Grid.SetRow(image, row);
                Grid.SetColumn(image, pokemonsCol);
                Grid.Children.Add(image);
                row++;
                //-------------------------------------------------------------------------------------------------------
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmptyGrid();
            string search = SearchBox.Text;
            int row = 0; // Increment this every time u add a pokemon
            int pokemonsCol = 2; // Maybe dont have to Increment this 
            int pokemonInfoCol = 1; // Maybe dont have to Increment this 
            if (search == "")
            {
                PrintPokemons();
            }
            else
            {
                foreach (var pokemon in seasonOne)
                {
                    if (pokemon.name.Contains(search))
                    {
                        RowDefinition x = new RowDefinition();
                        Grid.RowDefinitions.Add(x);
                        x.Height = new GridLength(150);
                        //-------------------------------------------------------------------------------------------------------
                        //                                      Adding Name and Type for Each Pokemon
                        //-------------------------------------------------------------------------------------------------------
                        TextBlock info = new TextBlock();
                        info.Text = $"   {pokemon.name} \n   ({pokemon.type})";
                        info.FontSize = 20;
                        info.VerticalAlignment = VerticalAlignment.Center;
                        info.HorizontalAlignment = HorizontalAlignment.Left;
                        info.Foreground = System.Windows.Media.Brushes.OrangeRed;
                        info.FontWeight = System.Windows.FontWeights.Bold;
                        info.FontStyle = System.Windows.FontStyles.Italic;

                        Grid.SetRow(info, row);
                        Grid.SetColumn(info, pokemonInfoCol);
                        Grid.Children.Add(info);
                        //-------------------------------------------------------------------------------------------------------
                        //-------------------------------------------------------------------------------------------------------
                        //                                      Adding Image     
                        //-------------------------------------------------------------------------------------------------------
                        Image image = new Image();
                        image.Source = new BitmapImage(new Uri(pokemon.image));
                        image.Height = 130;
                        image.Width = 130;
                        Grid.SetRow(image, row);
                        Grid.SetColumn(image, pokemonsCol);
                        Grid.Children.Add(image);
                        row++;
                        //-------------------------------------------------------------------------------------------------------
                    }
                }
            }
        }
    }
}
