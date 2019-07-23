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

        [Test]
        public void ShouldGetName()
        {
            //          Expected Value
            string expected = "Bulba";

            //          Actual Value
            string actual = PokemonGetData.GetPokemonName(_productListItems[0], 0);

            Assert.AreEqual(expected, actual);
        }

        public void ShouldGetImage()
        {
            string expected = "";
            string actual = "";
        }

        public void ShouldGetType()
        {
            string expected = "";
            string actual = "";
        }
    }
}
