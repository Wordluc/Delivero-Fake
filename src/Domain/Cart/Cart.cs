using Domain.Order;
using FluentResults;
#pragma warning disable CS8618

namespace Domain.Cart
{
    public partial class Cart
    {
        public Guid Id { get;internal set; }
        public Guid AccountId { get; internal set; }
        public Guid RestaurantId { get; internal set; }
        public List<SelectedDish> SelectedDishes {  get; internal set; }
        public float TotalCost { get { return CalculateTotalCostOrder(); } }
        private Cart() { }
        public static Result<Cart> New(Guid accountId,Guid restaurantId)
        {
            return Result.Ok(new Cart()
            {
                Id = Guid.NewGuid(),
                AccountId = accountId,
                RestaurantId=restaurantId,
                SelectedDishes = new()
            });
        }
        private float CalculateTotalCostOrder()
        {
            float totalCost = 0;
            foreach (var item in SelectedDishes)
            {
                totalCost += item.TotalCost;
            }
            return totalCost;
        }
    }
}