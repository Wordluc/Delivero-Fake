namespace Domain.Ristorante
{
    internal class Plate
    {
        public required Guid Id { get; internal set; }
        public required string NamePlate { get; internal set; }
        public required string Type {  get; internal set; }
        public required float Cost { get; internal set; }
        public required List<StepRecepi> Recipe { get; internal set; }
    }
    internal record StepRecepi(string Description, int NeededTime, List<Ingredient>? Ingredients);
    internal record Ingredient(string Name, List<Intolerance>? Intolerances);
    internal record Intolerance(string Name, string Description);

}