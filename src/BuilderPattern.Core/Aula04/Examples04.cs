
namespace BuilderPattern.Core.Aula04;
public class Car
{
    public string Model { get; private set; } = string.Empty;
    public short Year { get; private set; }
    public string Color { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Mileage { get; private set; }
    public short NumberOfDoors { get; private set; }
    public string Transmission { get; private set; } = string.Empty;

    public class CarBuilder
    {
        private readonly Car _car = new Car();

        public CarBuilder WithModel(string model)
        {
            _car.Model = model;
            return this;
        }

        public CarBuilder WithYear(short year)
        {
            _car.Year = year;
            return this;
        }

        public CarBuilder WithColor(string color)
        {
            _car.Color = color;
            return this;
        }

        public CarBuilder WithPrice(decimal price)
        {
            _car.Price = price;
            return this;
        }

        public CarBuilder WithMileage(int mileage)
        {
            _car.Mileage = mileage;
            return this;
        }

        public CarBuilder WithNumberOfDoors(short numberOfDoors)
        {
            _car.NumberOfDoors = numberOfDoors;
            return this;
        }

        public CarBuilder WithTransmission(string transmission)
        {
            _car.Transmission = transmission;
            return this;
        }

        public Car Build()
        {
            return _car;
        }
    }
}