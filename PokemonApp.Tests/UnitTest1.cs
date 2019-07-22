using System;
using NUnit.Framework;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace PokemonApp.Tests
{
    public class UnitTest1
    {
        HtmlDocument _pokemonPage;
        List<HtmlNode> _productListItems = new List<HtmlNode>();
        PokemonWindow _window;
        [SetUp]
        public void Setup()
        {
            _pokemonPage = new HtmlDocument();
            _pokemonPage.LoadHtml(Properties.Resources.PokemonPage);

            var producsHtml = _pokemonPage.DocumentNode.Descendants("div")
               .Where(node => node.GetAttributeValue("class", "")
               .Equals("infocard-list infocard-list-pkmn-lg")).ToList();

            _productListItems = producsHtml[0].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("infocard")).ToList();

        }

        [Test]
        public void CanGetPokemonName()
        {
            var name = PokemonOperation.GetPokemonName(_productListItems[0], 0);

            Assert.AreEqual("Bulbasaur", name);
        }

        //[Test]
        //public void TestMethod1()
        //{
        //}
    }
}
