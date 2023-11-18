
using Application;
using Application.Command.newRestaurant;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepository,Repository.Repository>();
builder.Services.AddhandlerMediator();
var app = builder.Build();


app.MapGet("/get", async ([FromBody] NewRestaurantCommands c, IMediator m) =>
{

    var result = await m.Send(c);

    return (result.IsSuccess is true)
        ?
         Results.Ok(result)
       :
         Results.BadRequest(result.Reasons);
});

app.Run();

