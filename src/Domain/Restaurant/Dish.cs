﻿namespace Domain.Restaurant
{
#pragma warning disable CS8618
    public class Dish
    {
        public Guid Id { get; internal set; } = Guid.NewGuid();
        public string NameDish { get; internal set; }
        public string Type { get; internal set; }
        public float Cost { get; internal set; }
        public List<Ingredient> Ingredients { get; internal set; }
        internal Dish() { }
    }
    public record Ingredient(string Name, List<Intolerance>? Intolerances);
    public record Intolerance(string Name, string Description);
    public enum TypeDish
    {
        First, Second, Desert
    }
}

