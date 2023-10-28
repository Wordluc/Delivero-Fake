using Domain.Ristorante;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Xunit;

namespace DomainTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddPlate_WithCorrectValue()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattoria Luca","Via bla bla",55)!;
            var r=restaurant.AddPlate("carbonara", 20, "first");

            r.Should().NotBe(default(Guid));
        }
     
        [Fact]
        public void CreateRecepi_WithCorrectValue()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattoria Luca", "Via bla bla", 55)!;
            var IdPlate=restaurant.AddPlate("cous cous", (float)1.5, "first");

            var ingredients = new List<Ingredient>()
            {
                new("patate",null),
                new("latte",new(){new("lattosio","vai in bagno")})
            };
            var r = restaurant.AddStepToPlateRecepi(IdPlate, "mescolare", 10, ingredients);

            r.Should().Be(true);
        }
        [Fact]
        public void CreateRecepi_WithIncorrectValue()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattoria Luca", "Via bla bla", 55)!;
            var IdPlate = restaurant.AddPlate("cous cous", (float)1.5, "first");
            var ingredients = new List<Ingredient>()
            {
                new("",null),
                new("latte",new(){new("lattosio","vai in bagno")})
            };
            var r = restaurant.AddStepToPlateRecepi(IdPlate, "mescolare", 10, ingredients);

            r.Should().Be(false);
        }
        [Fact]
        public void InsertRecepi_InNoExistingPlate()
        {
            Restaurant restaurant = Restaurant.CreateRestaurant("trattoria Luca", "Via bla bla", 55)!;

            var ingredients = new List<Ingredient>()
            {
                new("patate",null),
                new("latte",new()   
                                 {
                                    new("lattosio","vai in bagno")
                                 })
            };
            var r=restaurant.AddStepToPlateRecepi(Guid.NewGuid(), "mescolare", 10,ingredients); 
            
            r.Should().Be(false);
        }
        
    }
}