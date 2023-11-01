using Domain;
using Domain.Restaurant;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Xunit;

namespace DomainTests
{
    public class RestaurantAggregate
    {
        [Fact]
        public void CreateRestaurant_WithIncorrectName()
        {
            Restaurant restaurant = Restaurant.New("",new("mussomeli","Via bla bla",55))!;

            restaurant.Should().BeNull();
        }
        [Fact]
        public void ChangeAddress_WithOneIncorrect()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", new("mussomeli", "Via bla bla", 55))!;
            restaurant.SetAddress(new("mussomeli", "", -200)).Should().Be(false);
        }
        [Fact]
        public void CreateDish_WithIncorrectName_ShouldReturnFalse()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", new("mussomeli", "Via bla bla", 55))!;
            restaurant.AddNewDish("", 10, "First").Should().BeFalse();

        }
        [Fact]
        public void CreateDish_WithIncorrectCost_ShouldReturnFalse()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", new("mussomeli", "Via bla bla", 55))!;
            restaurant.AddNewDish("cous cous", -10, "First").Should().BeFalse();

        }
        [Fact]
        public void CreateDish_WithCorrectValue()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", new("mussomeli", "Via bla bla", 55))!;
            restaurant.AddNewDish("cous cous", 10, "First").Should().BeTrue();

        }
        [Fact]
        public void CreateDish_WithExistingUsedname_GetFalse()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", new("mussomeli", "Via bla bla", 55))!;
            restaurant.AddNewDish("cous cous", 10, "First");
            restaurant.AddNewDish("cous cous", 10, "First").Should().Be(false);

        }

        [Fact]
        public void CreatePlate_WithIncorrectIngredientsName_GetFalse()
        {
            Restaurant restaurant = Restaurant.New("trattoria da luca", new("mussomeli", "Via bla bla", 55))!;
            var newPlate= restaurant.AddNewDish("cous cous",10,"First");

            var ingredients = new List<Ingredient>()
            {
                new("",null),
                new(null!,new(){new("lattosio","vai in bagno")})
            };
            var r = restaurant.AddStepToDishsRecepi("cous cous", new( "mescolare", 10, ingredients));

            r.Should().Be(false);
        }
        [Fact]
        public void CreateRecepi_WithIncorrectDescriptionStep_GetFalse()
        {
            Restaurant restaurant = Restaurant.New("trattoria da luca", new("mussomeli", "Via bla bla", 55))!;
            var newPlate = restaurant.AddNewDish("cous cous", 10, "First");

            var ingredients = new List<Ingredient>()
            {
                new("patate",null),
                new("latte",new(){new("lattosio","vai in bagno")})
            };
            var r = restaurant.AddStepToDishsRecepi("cous cous",new( "", 10, ingredients));

            r.Should().Be(false);
        }

        [Fact]
        public void ChangeCost_WithIncorrectCorrectCost_KeepSameOldCost()
        {
            Restaurant restaurant = Restaurant.New("trattoria da luca", new("mussomeli", "Via bla bla", 55))!;
            var newPlate = restaurant.AddNewDish("cous cous", 10, "First");

            restaurant.UpdateDistCost("cous cous",-20);

            restaurant.GetDish("cous cous")!.Cost.Should().Be(10);
        }

    }
}