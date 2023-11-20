using System.Runtime.CompilerServices;
using Domain.Restaurant;
using Repository;
using Repository.ChainGet;

namespace GetDishByName;
internal class GetDishByIntollerance : IChain<Dish, GetDishParams>
{
    protected override bool CheckCondition(GetDishParams cmd)
    {
        if(cmd.Intollerance is null )return false;
        if(cmd.Intollerance.Count()<=0)return false;
        return true;
    }

    protected override IEnumerable<Dish> Execute(GetDishParams cmd, IEnumerable<Dish> collection)
    {
        return  collection.Where(x=>x.Ingredients.Select(c=>c.Intolerances).Distinct(cmd.)

    }
    private Dish? Selection(string intollerance,Dish dish){
           foreach(var i in dish.Ingredients){
            if(i.Intolerances!.Equals(intollerance))
                 return null;
           }
           return dish;
    }
}