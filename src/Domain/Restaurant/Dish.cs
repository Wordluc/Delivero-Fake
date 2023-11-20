namespace Domain.Restaurant;
#pragma warning disable CS8618
    public class Dish:IEqual<Dish>
    {
        public Guid Id { get; internal set; } = Guid.NewGuid();
        public string NameDish { get; internal set; }
        public string Type { get; internal set; }
        public decimal Cost { get; internal set; }
        public List<Ingredient> Ingredients { get; internal set; }
        internal Dish() { }

        public override bool Equals(Dish? other)
        {
            return Id == other?.Id;
        }
        public IEnumerable<string?> GetDishIntollerances()
        {
            foreach (Ingredient i in Ingredients)
            {
                if (i.Intolerances is null) continue;
                foreach (Intolerance intollerance in i.Intolerances)
                    yield return intollerance.Name;
            }
            yield return null;

        }
}
    public record Ingredient(string Name, List<Intolerance>? Intolerances);
    public record Intolerance(string Name, string Description);
    public enum TypeDish
    {
        First, Second, Desert
    }


