namespace Containers;

class FluidContainer : Container, IContainer, IHazardNotifier
{
    private double CargoWeight { get; set; }
    private double Height { get; }
    private double Weight { get; }
    private double Depth { get; }
    private char ContainerType { get; }
    private double MaximumCargoCapacity { get; }
    private static int Count = 0;
    private readonly bool HazardousCargo = false;

    public FluidContainer(double cargoWeight, double height, double weight, double depth, char containerType, double maximumCargoCapacity, bool hazardousCargo) : base(cargoWeight, height, weight, depth, containerType, maximumCargoCapacity)
    {
        this.CargoWeight = cargoWeight;
        this.Height = height;
        this.Weight = weight;
        this.Depth = depth;
        this.ContainerType = containerType;
        this.MaximumCargoCapacity = maximumCargoCapacity;
        this.HazardousCargo = hazardousCargo;
    }

    public void NotifyHazard()
    {
        Console.WriteLine("Hazardous situation with container "+GetSerialNumber());
    }

    public void DumpCargo()
    {
        CargoWeight = 0;
        Console.WriteLine("Cargo dumped.");
    }

    public void LoadCargo(double cargoWeight)
    {
        if (HazardousCargo)
        {
            if (this.CargoWeight+cargoWeight > MaximumCargoCapacity * 0.5)
            {
                NotifyHazard();
                return;
            }
            if (this.CargoWeight + cargoWeight > MaximumCargoCapacity)
                throw new OverfillException("Cargo weight exceeds maximum cargo capacity!");
            else
                this.CargoWeight += cargoWeight;
        }
        else
        {
            if (this.CargoWeight + cargoWeight > MaximumCargoCapacity * 0.9)
            {
                NotifyHazard();
                return;
            }
            
            if (this.CargoWeight + cargoWeight > MaximumCargoCapacity)
                throw new OverfillException("Cargo weight exceeds maximum cargo capacity!");
            else
                this.CargoWeight += cargoWeight;
        }
    }

    public override string ToString()
    {
        return $"Container number: {GetSerialNumber()}, container type: {ContainerType}, container height: {Height}, container weight: {Weight}, container depth: {Depth}, container maximum capacity: {MaximumCargoCapacity}, container current cargo weight {CargoWeight}, container current weight: {CargoWeight+Weight}, hazardous cargo: {HazardousCargo}";
    }
}