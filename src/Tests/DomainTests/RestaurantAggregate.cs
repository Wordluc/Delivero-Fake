using Domain;
using Domain.Common;
using Domain.Restaurant;
using FluentAssertions;
using FluentResults;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Xunit;

namespace DomainTests
{
    public class RestaurantAggregate
    {
        [Fact]
        public void CreateRestaurant_WithIncorrectName()
        {
            var address = Address.New("mussomeli", "Via bla bla", 55);
            Result<Restaurant> restaurantResult = Restaurant.New("",address.Value);

            restaurantResult.IsFailed.Should().BeTrue();
        }
        [Fact]
        public void CreateAddress_Incorrect()
        {
            var address = Address.New("mussomeli", "", 55);
            address.IsFailed.Should().BeTrue();
        }
        [Fact]
        public void CreateDish_WithIncorrectName_ShouldReturnFalse()
        {
            var address = Address.New("mussomeli", "Via bla bla", 55);

            Restaurant restaurant = Restaurant.New("trattotrai", address.Value).Value;
            restaurant.AddNewDish("", 10, "First").Should().BeFalse();

        }
        [Fact]
        public void CreateDish_WithIncorrectCost_ShouldReturnFalse()
        {
            var address = Address.New("mussomeli", "Via bla bla", 55);

            Restaurant restaurant = Restaurant.New("trattotrai", address.Value).Value ;
            restaurant.AddNewDish("cous cous", -10, "First").Should().BeFalse();

        }
        [Fact]
        public void CreateDish_WithCorrectValue()
        {
            var address = Address.New("mussomeli", "Via bla bla", 55);

            Restaurant restaurant = Restaurant.New("trattotrai", address.Value).Value;
            restaurant.AddNewDish("cous cous", 10, "First").Should().BeTrue();

        }
        [Fact]
        public void CreateDish_WithExistingUsedname_GetFalse()
        {
            var address = Address.New("mussomeli", "Via bla bla", 55);

            Restaurant restaurant = Restaurant.New("trattotrai", address.Value).Value;
            restaurant.AddNewDish("cous cous", 10, "First");
            restaurant.AddNewDish("cous cous", 10, "First").Should().Be(false);

        }

        [Fact]
        public void CreatePlate_WithIncorrectIntollerance_GetFalse()
        {
            var address = Address.New("mussomeli", "Via bla bla", 55);

            Restaurant restaurant = Restaurant.New("trattoria da luca", address.Value).Value;
            restaurant.AddNewDish("cous cous",10,"First");

            Ingredient ingredient =
                new("lattosio",
                    new() { new("latto", "") });
            
            var r = restaurant.AddIngredient("cous cous", ingredient);

            r.Should().Be(false);
        }
        [Fact]
        public void CreateIngridient_WithIncorrectName()
        {
            var address = Address.New("mussomeli", "Via bla bla", 55);

            Restaurant restaurant = Restaurant.New("trattoria da luca", address.Value).Value;
            restaurant.AddNewDish("cous cous", 10, "First");

            Ingredient ingredient =
                new("",
                           new() { 
                               new("lattosio", "vai in bagno") 
                           });
            var r = restaurant.AddIngredient("cous cous",ingredient);

            r.Should().Be(false);
        }

        [Fact]
        public void ChangeCost_WithIncorrectCorrectCost_KeepSameOldCost()
        {
            var address = Address.New("mussomeli", "Via bla bla", 55);

            Restaurant restaurant = Restaurant.New("trattoria da luca", address.Value).Value;
            restaurant.AddNewDish("cous cous", 10, "First");

            restaurant.UpdateDistCost("cous cous",-20);

            restaurant.GetDish("cous cous")!.Cost.Should().Be(10);
        }
        [Fact]
        public void ChangeCost_WithCorrectCost()
        {
            var address = Address.New("mussomeli", "Via bla bla", 55);

            Restaurant restaurant = Restaurant.New("trattoria da luca", address.Value).Value;
            restaurant.AddNewDish("cous cous", 10, "First");

            restaurant.UpdateDistCost("cous cous", 20);

            restaurant.GetDish("cous cous")!.Cost.Should().Be(20);
        }

    }
}