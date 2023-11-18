
using Application;
using Application.Command;
using Application.Command.getRestaurant;
using Application.Command.newRestaurant;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepository();
builder.Services.AddhandlerMediator();
var app = builder.Build();


app.MapPost("/Restaurant/add", async ([FromBody] NewRestaurantCommands c, IMediator m) =>
{

    var result = await m.Send(c);

    return (result.IsSuccess is true)
        ?
         Results.Ok(result.Value)
       :
         Results.BadRequest(result.Reasons);
});


app.MapGet("/Restaurant/get", async ([FromBody] GetRestaurantCommands c, IMediator m) =>
{

    var result = await m.Send(c);

    return (result.IsSuccess is true)
        ?
         Results.Ok(result.Value)
       :
         Results.BadRequest(result.Reasons);
});

app.Run();

