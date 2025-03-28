namespace Containers;

class Product(string Name, double RequiredTemperature)
{
    private readonly string _name = Name;
    private readonly double _requiredTemperature = RequiredTemperature;

    public string GetName()
    {
        return _name;
    }

    public double GetRequiredTemperature()
    {
        return _requiredTemperature;
    }
}