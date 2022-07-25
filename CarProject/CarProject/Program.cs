public class Vehicle {
    public string name;
    public int tankCapacity;
    public int avarageConsumption;
    public int speed;
    public int fuelLevel;

    public Vehicle(string name, int tankCapacity, int avarageConsumption, int speed, int fuelLevel)
    {
        this.name = name;
        this.tankCapacity = tankCapacity;
        this.avarageConsumption = avarageConsumption;
        this.speed = speed;
        this.fuelLevel = fuelLevel;
    }
    
    
    public string toString() {
        return "Name: " + name + "\nTank Capacity: " + tankCapacity + "\nAvarage Consumption: " + avarageConsumption + "\nSpeed: " + speed;
    }

    public virtual double calculateDistanceWithCurrentFuelLevel() {
        return fuelLevel * speed / avarageConsumption;
    }

    

    public int calculateTime(int fuelLevel, int distance)
    {
        return distance / (fuelLevel * speed / avarageConsumption);
    }
}

public class Car : Vehicle
{
    public Car(string name, int tankCapacity, int avarageConsumption, int speed, int fuelLevel, int passangerCount = 0) : base(name, tankCapacity, avarageConsumption, speed, fuelLevel)
    {
        this.passangerCount = passangerCount;
    }

    public int passangerCount { get; set; }
    
    public override double calculateDistanceWithCurrentFuelLevel()
    {
        return (double)(fuelLevel * speed / avarageConsumption) - (double)(passangerCount * 6);
    }
    
}

public class Truck : Vehicle
{
    
    public Truck(string name, int tankCapacity, int avarageConsumption, int speed, int cargo, int fuelLevel) : base(name, tankCapacity, avarageConsumption, speed,  fuelLevel) {Cargo = cargo; }
    
    public int Cargo { get; set; }
    public const int fullTank = 100;
    
    public int calculateDistanceWithFullFuelLevel() {
        return fullTank * speed / avarageConsumption;
    }

    public override double calculateDistanceWithCurrentFuelLevel()
    {
        return (fuelLevel * speed / avarageConsumption) - ((Cargo / 200) * 4);
    }

    public  double calculateDistanceWithCurrentFuelLevel(int fuelLevel)
    {
        return (fuelLevel * speed / avarageConsumption) - ((Cargo / 200) * 4);
    }
    

    public bool canContainCargo(int cargoWeight)
    {
        if (calculateDistanceWithCurrentFuelLevel(cargoWeight) <= 0)
            return false;

        return true;
    }
}

public class Program
{
    public static void Main()
    {
        var car = new Car("BMW", 100, 10, 10, 100, 13);
        Console.WriteLine(car.toString());
        Console.WriteLine(car.calculateDistanceWithCurrentFuelLevel());
        

        var truck = new Truck("Mercedes", 100, 10, 10, 1, 1);
        Console.WriteLine(truck.toString());
        Console.WriteLine(truck.calculateDistanceWithCurrentFuelLevel());
    }
}