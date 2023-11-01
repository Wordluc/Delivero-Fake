namespace Domain.Cart
{
    public partial class Cart
    {
        public Guid Id { get;internal set; }
        public Guid RestaurantId { get; internal set; }
        public List<BookedDish> BookedDishs {  get; internal set; } 
        public Order Order { get; internal set; }
    }
    public record BookedDish(string NameDish,int Quantity);
}