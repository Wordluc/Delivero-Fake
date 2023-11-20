using Domain.Restaurant;
using Repository;
using Repository.ChainGet;

namespace GetDishByName;
internal class GetDishByName : IChain<Dish, GetDishParams>
{
    protected override bool CheckCondition(GetDishParams cmd)
    {
        if(cmd.Name is null)return false;
        return true;
    }

    protected override IEnumerable<Dish> Execute(GetDishParams cmd, IEnumerable<Dish> collection)
    {
        return collection.Where(x=>x.NameDish==cmd.Name);
    }
}