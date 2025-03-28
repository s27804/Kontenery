namespace Containers;

class RefrigeratedContainer : Container, IContainer
{
    private double CargoWeight { get; set; }
    private double Height { get; }
    private double Weight { get; }
    private double Depth { get; }
    private char ContainerType { get; }
    private double MaximumCargoCapacity { get; }
    private static int Count = 0;
    private string SerialNumber { get; }
    private Product Product { get; set; }
    private double ContainerTemperature { get; }

    public RefrigeratedContainer(double cargoWeight, double height, double weight, double depth, char containerType, double maximumCargoCapacity, string serialNumber, Product product, double containerTemperature) : base(cargoWeight, height, weight, depth, containerType, maximumCargoCapacity)
    {
        this.CargoWeight = cargoWeight;
        this.Height = height;
        this.Weight = weight;
        this.Depth = depth;
        this.ContainerType = containerType;
        this.MaximumCargoCapacity = maximumCargoCapacity;
        this.SerialNumber = "KON-" + containerType + ++Count;
        this.Product = product;
        this.ContainerTemperature = containerTemperature;
    }

    public void DumpCargo()
    {
        CargoWeight = 0;
    }

    public void LoadCargo(double cargoWeight, Product product)
    {
        if (this.CargoWeight + cargoWeight > MaximumCargoCapacity)
            throw new OverfillException("Cargo weight exceeds maximum cargo capacity!");
        else if (this.Product.GetName() != product.GetName())
        {
            throw new Exception("Cannot load two different cargoes!");
        }
        else if(product.GetRequiredTemperature() > ContainerTemperature)
        {
            throw new Exception("Container temperature is lower than reuired temperature for the cargo!");
        }
        else
            this.CargoWeight += cargoWeight;
    }
    
    public override string ToString()
    {
        return $"Container number: {GetSerialNumber()}, container type: {ContainerType}, container height: {Height}, container weight: {Weight}, container depth: {Depth}, container maximum capacity: {MaximumCargoCapacity}, container current cargo weight {CargoWeight}, container current weight: {CargoWeight+Weight}, product: {Product.GetName()}, container temperature: {ContainerTemperature}";
    }
}