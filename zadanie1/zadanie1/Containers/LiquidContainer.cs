namespace zadanie1.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsDangerous { get; }
    
    public LiquidContainer(double containerHeight, double containerWeight, double containerDepth, char typeContainer, double containerCapacity, bool isDangerous) : base(containerHeight, containerWeight, containerDepth, 'L', containerCapacity)
    {
        IsDangerous = isDangerous;
    }


    public void LoadCargo(double cargoW)
    {
        double check;
        if (IsDangerous)
        {
            InfoHazard($"Attempting to load dangerous liquid into {serialNumber}");
            check = containerCapacity * 0.5;
        }
        else
        {
            check = containerCapacity * 0.9;
        }

        if (cargoW > check)
        {
            InfoHazard($"Overfill attempt on {serialNumber}");
            throw new OverfillException($"Can't load more than {check}kg on {serialNumber}");
        }

        cargoWeight = cargoW;
    }
    
    public void InfoHazard(string message)
    {
        Console.WriteLine($"DANGEROUS - Liquid: {message}");
    }
    public string ToString()
    {
        string info = base.ToString();
        if (IsDangerous)
        {
            InfoHazard($"{serialNumber}");
        }
        return info;
    }
}