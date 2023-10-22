namespace Domain.Ristorante
{
    public class MenuItems
    {
        public required Guid Id { get; set; }
        public required string NamePlate { get; set; }
        public required string Type {  get; set; }
        public required float Cost { get; set; }
        public required List<Step> Recipe { get; set; }
    }
}