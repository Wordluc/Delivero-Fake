namespace Domain.Plate
{
#pragma warning disable CS8618
    public partial class Plate
    {
        public Guid Id { get; internal set; }
        public string NamePlate { get; internal set; }
        public string Type { get; internal set; }
        public float Cost { get; internal set; }
        public List<StepRecepi> Recipe { get; internal set; }
    }
    public record StepRecepi(string Description, int NeededTime, List<Ingredient>? IIngredients);
    public record Ingredient(string Name, List<Intolerance>? Intolerances);
    public record Intolerance(string Name, string Description);

}