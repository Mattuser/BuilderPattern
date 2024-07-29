using BuilderPattern.Core.Aula04;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/v1/cars", CreateCar);

static IResult CreateCar()
{
    var car = new Car.CarBuilder()
        .WithModel("Beetle")
        .WithYear(1969)
        .WithColor("Red")
        .WithPrice(15000)
        .WithMileage(80000)
        .WithNumberOfDoors(2)
        .WithTransmission("Manual")
        .Build();

    var response = new Response<Car>(car, 400);

    return response.IsSuccess
       ? TypedResults.Ok(response)
       : TypedResults.BadRequest(response);
}


app.Run();


class Response<T>
{
    private readonly int _statusCode;
    internal Response(T data, int statusCode = 200)
    {
        Data = data;
        _statusCode = statusCode;
    }
    public List<string> Notifications = new();
    public T? Data { get; set; }

    [JsonIgnore]
    public bool IsSuccess  => _statusCode is >= 200 and <= 299; 
}