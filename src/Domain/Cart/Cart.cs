using Domain.Order;
using FluentResults;
#pragma warning disable CS8618

namespace Domain.Cart
{
    public partial class Cart:IEqual<Cart>
    {
        public Guid Id { get;private set; }
        public Guid AccountId { get; private set; }
        public Guid RestaurantId { get; private set; }
        public List<SelectedDish> SelectedDishes {  get; private set; }
        public decimal TotalCost { get { return CalculateTotalCostCart(); } }
        private Cart() { }

        public override bool Equals(Cart? other)
        {
            return Id == other?.Id;
        }
    }
}