namespace Containers;

public class ContainerShip
{
    private List<Container> _containerList = new List<Container>();
    private double MaximumSpeed;
    private double MaximumContainerCapacity;
    private double MaximumOverallContainerWeight;

    public ContainerShip(double maximumSpeed, double maximumContainerCapacity, double maximumOverallContainerWeight)
    {
        MaximumSpeed = maximumSpeed;
        MaximumContainerCapacity = maximumContainerCapacity;
        MaximumOverallContainerWeight = maximumOverallContainerWeight;
    }

    public void LoadContainer(Container container)
    {
        _containerList.Add(container);
        Console.WriteLine("Container loaded");
    }

    public void LoadContainer(List<Container> containerList)
    {
        _containerList.AddRange(containerList);
        Console.WriteLine("Container list loaded");
    }

    public void UnloadContainer(Container container)
    {
        _containerList.Remove(container);
        Console.WriteLine("Container unloaded");
    }

    public void ReplaceExistingContainer(string containerNumber, Container container)
    {
        if (containerNumber == container.GetSerialNumber())
        {
            Console.WriteLine("Cannot replace a container, that has already been loaded");
        }
        try
        {
            int oldContainer = _containerList.FindIndex(c => c.GetSerialNumber() == containerNumber);
            _containerList[oldContainer] = container;
            Console.WriteLine("Container replaced");
        }
        catch (Exception e)
        {
                Console.WriteLine("There's no container with the provided number");
        }
    }

    public void PrintContainerList()
    {
        string result = "";
        foreach (Container c in _containerList)
        {
            result += c.GetSerialNumber() + ", ";
        }
        if (result != "")
            Console.WriteLine(result.Remove(result.Length - 2, 2));
        else
            Console.WriteLine(result);
    }
    
    public string PrintContainerListString()
    {
        string result = "";
        foreach (Container c in _containerList)
        {
            result += c.GetSerialNumber() + ", ";
        }
        if (result != "")
            return result.Remove(result.Length - 2, 2);
        else
            return result;
    }

    public List<Container> GetContainerList()
    {
        return _containerList;
    }

    public override string ToString()
    {
        return $"Loaded containers: {PrintContainerListString()}; ship maximum speed: {MaximumSpeed}, ship maximum container capacity: {MaximumContainerCapacity}, ship maximum overall container weight: {MaximumOverallContainerWeight}";
    }
}