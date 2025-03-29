namespace zadanie1.Containers;

public class Ship
{

    private double maxSpeed; //wezly
    private int maxContainers;
    private double maxContainersWeight; //wszystkie kontenery transportowane na statku (w tonach)
    
    private List<Container> containers = new ();
    
    public Ship(double speed, int containers, double weight)
    {
        maxSpeed = speed;
        maxContainers = containers;
        maxContainersWeight = weight;
    }
    
    public void LoadContainer(Container container)
    {
        if(containers.Count >= maxContainers)
            throw new Exception("Too many containers");
        double totalWeight = 0;

        foreach (var c in containers)
            totalWeight += c.cargoWeight + c.containerWeight;

        double totalWeightTons = totalWeight / 1000;
        if(totalWeightTons > maxContainersWeight)
            throw new Exception("Too heavy");
        
        containers.Add(container);
    }

    public void LoadContainers(List<Container> listContainers)
    {
        foreach (var c in listContainers)
            LoadContainer(c);
    }

    public void RemoveContainer(string serialNumber)
    {
        foreach (var container in containers)
        {
            if (container.serialNumber == serialNumber)
            {
                containers.Remove(container);
                return;
            }
        }
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = containers.FirstOrDefault(c => c.serialNumber == serialNumber);
        if (container == null)
            throw new Exception($"Container {serialNumber} not found.");

        container.Emptying();
    }

    public void ReplaceContainer(string oldSerialNumber, Container newContainer)
    {
        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].serialNumber == oldSerialNumber)
            {
                containers[i] = newContainer;
                return;
            }
        }

        throw new Exception($"Container with serial {oldSerialNumber} not found.");
    }

    public void SwapContainer(Ship otherShip, string serialNumber)
    {
        Container? containerToMove = null;

        foreach (var c in containers)
        {
            if (c.serialNumber == serialNumber)
            {
                containerToMove = c;
                break;
            }
        }

        if (containerToMove == null)
            throw new Exception($"Container {serialNumber} not found on this ship.");

        otherShip.LoadContainer(containerToMove);
        containers.Remove(containerToMove);
    }
    
    public void PrintShipInfo()
    {
        Console.WriteLine("=== SHIP INFO ===");
        Console.WriteLine($"Max speed: {maxSpeed} knots");
        Console.WriteLine($"Max containers: {maxContainers}");
        Console.WriteLine($"Max weight (tons): {maxContainersWeight}");
        Console.WriteLine($"Loaded containers: {containers.Count}");

        foreach (var c in containers)
            Console.WriteLine(c.ToString());
    }
    
    
}