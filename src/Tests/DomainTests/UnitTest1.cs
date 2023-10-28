using Domain;
using Domain.Plate;
using Domain.Ristorante;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Xunit;

namespace DomainTests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateRestaurant_WithIncorrectName()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("","Via bla bla",55)!;

            restaurant.Should().BeNull();
        }
     
        [Fact]
        public void CreatePlate_WithIncorrectIngredientsName()
        {
            var newPlate= Plate.Create("cous cous",10,"first");

            var ingredients = new List<Ingredient>()
            {
                new("",null),
                new(null,new(){new("lattosio","vai in bagno")})
            };
            var r = newPlate.AddStepToRecepi("mescolare", 10, ingredients);

            r.Should().Be(false);
        }
        [Fact]
        public void CreateRecepi_WithIncorrectDescriptionStep()
        {
            var newPlate = Plate.Create("cous cous", 100, "first");
            var ingredients = new List<Ingredient>()
            {
                new("patate",null),
                new("latte",new(){new("lattosio","vai in bagno")})
            };
            var r = newPlate.AddStepToRecepi("", 10, ingredients);

            r.Should().Be(false);
        }
         
    }
}