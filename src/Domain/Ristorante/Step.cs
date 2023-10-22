namespace Domain.Ristorante
{
    public class Step
    {
        public required string Description { get; set; }
        public int NeededTime { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
    }
}