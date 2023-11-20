using Application;
using Domain.Restaurant;
using Repository;
using Repository.ChainGet;

namespace GetDishByName;
internal class GetDishByType : IChain<Dish, GetDishesParams>
{
    protected override bool CheckCondition(GetDishesParams cmd)
    {
        if(cmd.Type is null)return false;
        return true;
    }

    protected override IEnumerable<Dish?> Execute(GetDishesParams cmd, IEnumerable<Dish?> collection)
    {
        return collection.Where(x=>x is not null && x.Type.Equals(cmd.Type));
    }
}