namespace Containers;

class GasContainer : Container, IContainer, IHazardNotifier
{
    private double CargoWeight { get; set; }
    private double Height { get; }
    private double Weight { get; }
    private double Depth { get; }
    private char ContainerType { get; }
    private double MaximumCargoCapacity { get; }
    private double Pressure { get; set; }
    private static int Count = 0;
    private string SerialNumber { get; }

    public GasContainer(double cargoWeight, double height, double weight, double depth, char containerType, double maximumCargoCapacity, double pressure, string serialNumber) : base(cargoWeight, height, weight, depth, containerType, maximumCargoCapacity)
    {
        this.CargoWeight = cargoWeight;
        this.Height = height;
        this.Weight = weight;
        this.Depth = depth;
        this.ContainerType = containerType;
        this.MaximumCargoCapacity = maximumCargoCapacity;
        this.Pressure = pressure;
        SerialNumber = "KON-" + containerType + ++Count;
    }

    public void NotifyHazard()
    {
        Console.WriteLine("Hazardous situation with container " + SerialNumber);
    }

    public void DumpCargo()
    {
        CargoWeight = CargoWeight*0.05;
    }

    public void LoadCargo(double cargoWeight)
    {
        if (this.CargoWeight + cargoWeight > MaximumCargoCapacity)
            throw new OverfillException("Cargo weight exceeds maximum cargo capacity!");
        else
            this.CargoWeight += cargoWeight;
    }
    
    public override string ToString()
    {
        return $"Container number: {GetSerialNumber()}, container type: {ContainerType}, container height: {Height}, container weight: {Weight}, container depth: {Depth}, container maximum capacity: {MaximumCargoCapacity}, container current cargo weight {CargoWeight}, container current weight: {CargoWeight+Weight}, pressure: {Pressure}";
    }
}