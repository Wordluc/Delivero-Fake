namespace Domain.Ristorante
{
    public class Plate
    {
        public required Guid Id { get; set; }
        public required string NamePlate { get; set; }
        public required string Type {  get; set; }
        public required float Cost { get; set; }
        public required List<StepRecepi> Recipe { get; set; }
    }
    public record StepRecepi(string Description, int NeededTime, List<Ingredient>? IIngredients);
    public record Ingredient(string Name, List<Intolerance>? Intolerances);
    public record Intolerance(string Name, string Description);

}