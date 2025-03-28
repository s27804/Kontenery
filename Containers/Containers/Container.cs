namespace Containers;

public class Container()
{
    private double cargoWeight;
    private double height;
    private double weight;
    private double depth;
    private char containerType;
    private double maximumCargoCapacity;
    private static int Count = 0;
    private string _serialNumber;

    public Container(double cargoWeight, double height, double weight, double depth, char containerType, double maximumCargoCapacity) : this()
    {
        this.cargoWeight = cargoWeight;
        this.height = height;
        this.weight = weight;
        this.depth = depth;
        this.containerType = containerType;
        this.maximumCargoCapacity = maximumCargoCapacity;
        _serialNumber = "KON-" + containerType + "-" + ++Count;
    }

    public void ReloadContainer(ContainerShip containerShip1, ContainerShip containerShip2)
    {
        containerShip1.UnloadContainer(this);
        containerShip2.LoadContainer(this);
    }

    public double GetCargoWeight()
    {
        return cargoWeight;
    }

    public double GetHeight()
    {
        return height;
    }

    public double GetDepth()
    {
        return depth;
    }

    public char GetContainerType()
    {
        return containerType;
    }

    public double GetMaximumCargoCapacity()
    {
        return maximumCargoCapacity;
    }

    public string GetSerialNumber()
    {
        return _serialNumber;
    }

    public override string ToString()
    {
        return $"Container number: {_serialNumber}, container type: {containerType}, container height: {height}, container weight: {weight}, container depth: {depth}, container maximum capacity: {maximumCargoCapacity}, container current cargo weight {cargoWeight}, container current weight: {cargoWeight+weight}";
    }
}