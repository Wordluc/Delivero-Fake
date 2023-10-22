namespace Domain.Ristorante
{
    public class Ingredient
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required List<Intolerance>? Intolerances { get; set; }
    }
}