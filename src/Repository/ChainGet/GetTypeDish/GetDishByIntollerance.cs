using System.Runtime.CompilerServices;
using Application;
using Domain.Restaurant;
using Repository;
using Repository.ChainGet;

namespace GetDishByName;
internal class GetDishByIntollerance : IChain<Dish, GetDishesParams>
{
    protected override bool CheckCondition(GetDishesParams cmd)
    {
        if(cmd.Intollerance is null )return false;
        if(cmd.Intollerance.Count<=0)return false;
        return true;
    }

    protected override IEnumerable<Dish> Execute(GetDishesParams cmd, IEnumerable<Dish> collection)
    {
        return collection.SkipWhile(x=>PassIntollerance(cmd.Intollerance!, x));

    }
    private bool PassIntollerance(IEnumerable<string> intollerances,Dish dish)
    {
        foreach(var i in intollerances)
              if (dish.GetDishIntollerances().Contains(i)) return false;
        return true;
    }
}