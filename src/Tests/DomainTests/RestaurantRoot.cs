using Domain;
using Domain.Ristorante;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Xunit;

namespace DomainTests
{
    public class RestaurantRoot
    {
        [Fact]
        public void CreateRestaurant_WithIncorrectName()
        {
            Restaurant restaurant = Restaurant.New("","mussomeli","Via bla bla",55)!;

            restaurant.Should().BeNull();
        }
        [Fact]
        public void ChangeAddress_WithOneIncorrect()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", "mussomeli", "Via bla bla", 55)!;
            restaurant.SetAddress("mussomeli", "", -200).Should().Be(false);
        }
        [Fact]
        public void CreateDish_WithIncorrectName_ShouldReturnFalse()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", "mussomeli", "Via bla bla", 55)!;
            restaurant.AddNewDish("", 10, "First").Should().BeFalse();

        }
        [Fact]
        public void CreateDish_WithIncorrectCost_ShouldReturnFalse()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", "mussomeli", "Via bla bla", 55)!;
            restaurant.AddNewDish("cous cous", -10, "First").Should().BeFalse();

        }
        [Fact]
        public void CreateDish_WithCorrectValue()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", "mussomeli", "Via bla bla", 55)!;
            restaurant.AddNewDish("cous cous", 10, "First").Should().NotBeNull();

        }
        [Fact]
        public void CreateDish_WithExistingUsedname_GetNull()
        {
            Restaurant restaurant = Restaurant.New("trattotrai", "mussomeli", "Via bla bla", 55)!;
            restaurant.AddNewDish("cous cous", 10, "First");
            restaurant.AddNewDish("cous cous", 10, "First").Should().Be(null);

        }

        [Fact]
        public void CreatePlate_WithIncorrectIngredientsName_GetFalse()
        {
            Restaurant restaurant = Restaurant.New("trattoria da luca", "mussomeli", "Via bla bla", 55)!;
            var newPlate= restaurant.AddNewDish("cous cous",10,"First");

            var ingredients = new List<Ingredient>()
            {
                new("",null),
                new(null!,new(){new("lattosio","vai in bagno")})
            };
            var r = restaurant.AddStepToDishsRecepi("cous cous", "mescolare", 10, ingredients);

            r.Should().Be(false);
        }
        [Fact]
        public void CreateRecepi_WithIncorrectDescriptionStep_GetFalse()
        {
            Restaurant restaurant = Restaurant.New("trattoria da luca", "mussomeli", "Via bla bla", 55)!;
            var newPlate = restaurant.AddNewDish("cous cous", 10, "First");

            var ingredients = new List<Ingredient>()
            {
                new("patate",null),
                new("latte",new(){new("lattosio","vai in bagno")})
            };
            var r = restaurant.AddStepToDishsRecepi("cous cous", "", 10, ingredients);

            r.Should().Be(false);
        }

        [Fact]
        public void ChangeCost_WithIncorrectCorrectCost_KeepSameOldCost()
        {
            Restaurant restaurant = Restaurant.New("trattoria da luca", "mussomeli", "Via bla bla", 55)!;
            var newPlate = restaurant.AddNewDish("cous cous", 10, "First");

            restaurant.SetDishCost("cous cous",-20);

            restaurant.GetDish("cous cous")!.Cost.Should().Be(10);
        }

    }
}