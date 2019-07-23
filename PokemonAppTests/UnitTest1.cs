using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using NUnit.Framework;
using System.Linq;
using PokemonAppTests;
using PokemonApp;

namespace PokemonAppTests
{
    public class UnitTest1
    {
        HtmlDocument _pokemonPage;
        List<HtmlNode> _productListItems = new List<HtmlNode>();

        [SetUp]
        public void Setup()
        {
            _pokemonPage = new HtmlDocument();
            _pokemonPage.LoadHtml(Properties.Resources.page);

            var producsHtml = _pokemonPage.DocumentNode.Descendants("div")
               .Where(node => node.GetAttributeValue("class", "")
               .Equals("infocard-list infocard-list-pkmn-lg")).ToList();

            _productListItems = producsHtml[0].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("infocard")).ToList();

        }

        [Test, TestCaseSource("PokemonNames")]
        public void ShouldGetName(string expected, int index)
        {
            //          Expected Value
            //string expected = "Bulbasaur";

            //          Actual Value
            string actual = PokemonGetData.GetPokemonName(_productListItems[index], index);

            Assert.AreEqual(expected, actual);
        }

        static object[] PokemonNames =
        {
            new object[] {"Bulbasaur", 0},
            new object[] {"Ivysaur", 1},
            new object[] {"Venusaur", 2},
            new object[] {"Mew", 150} // Getting The Last Pokemon
        };

        [Test]
        public void ShouldGetImage()
        {
            //          Expected Value
            string expected = "https://img.pokemondb.net/sprites/omega-ruby-alpha-sapphire/dex/normal/ivysaur.png";

            //          Actual Value
            string actual = PokemonGetData.GetPokemonImage(_productListItems[1], 1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldGetType()
        {
            //          Expected Value
            string expected = "Psychic";

            //          Actual Value
            string actual = PokemonGetData.GetPokemonType(_productListItems[150], 150); // Checking The Last Pokemon Of Season One

            Assert.AreEqual(expected, actual);
        }
    }
}
