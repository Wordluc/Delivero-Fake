using Domain;
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
        public void ChangeAddress_WithOneIncorrect()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattotrai", "Via bla bla", 55)!;
            restaurant.SetAddress("", -200).Should().Be(false);
        }
        [Fact]
        public void CreateDish_WithIncorrectName_ShouldReturnNull()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattotrai", "Via bla bla", 55)!;
            restaurant.AddNewDish("", 10, "First").Should().BeNull();

        }
        [Fact]
        public void CreateDish_WithIncorrectCost_ShouldReturnNull()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattotrai", "Via bla bla", 55)!;
            restaurant.AddNewDish("cous cous", -10, "First").Should().BeNull();

        }
        [Fact]
        public void CreateDish_WithCorrectValue()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattotrai", "Via bla bla", 55)!;
            restaurant.AddNewDish("cous cous", 10, "First").Should().NotBeNull();

        }
        [Fact]
        public void CreateDish_WithUsedName()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattotrai", "Via bla bla", 55)!;
            restaurant.AddNewDish("cous cous", 10, "First");
            restaurant.AddNewDish("cous cous", 10, "First").Should().Be(null);

        }

        [Fact]
        public void CreatePlate_WithIncorrectIngredientsName()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattoria da luca", "Via bla bla", 55)!;
            var newPlate= restaurant.AddNewDish("cous cous",10,"first");

            var ingredients = new List<Ingredient>()
            {
                new("",null),
                new(null!,new(){new("lattosio","vai in bagno")})
            };
            var r = restaurant.AddStepToDishsRecepi(newPlate,"mescolare", 10, ingredients);

            r.Should().Be(false);
        }
        [Fact]
        public void CreateRecepi_WithIncorrectDescriptionStep()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattoria da luca", "Via bla bla", 55)!;
            var newPlate = restaurant.AddNewDish("cous cous", 10, "first");

            var ingredients = new List<Ingredient>()
            {
                new("patate",null),
                new("latte",new(){new("lattosio","vai in bagno")})
            };
            var r = restaurant.AddStepToDishsRecepi(newPlate,"", 10, ingredients);

            r.Should().Be(false);
        }
         
    }
}