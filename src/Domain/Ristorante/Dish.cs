namespace Domain.Ristorante
{
#pragma warning disable CS8618
    public class Dish
    {
        public Guid Id { get; internal set; } = Guid.NewGuid();
        public string NameDish { get; internal set; }
        public TypeDish Type { get; internal set; }
        public float Cost { get; internal set; }
        public List<StepRecepi> Recipe { get; internal set; }
        internal Dish() { }
    }
    public record StepRecepi(string Description, int NeededTime, List<Ingredient>? IIngredients);
    public record Ingredient(string Name, List<Intolerance>? Intolerances);
    public record Intolerance(string Name, string Description);

}