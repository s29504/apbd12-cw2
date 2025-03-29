namespace zadanie1.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }
    
    public GasContainer(double containerHeight, double containerWeight, double containerDepth, char typeContainer, double containerCapacity, double pressure) : base(containerHeight, containerWeight, containerDepth, 'G', containerCapacity)
    {
        Pressure = pressure;
    }

    public void UnloadCargo(double weight)
    {
        cargoWeight *= 0.05;
    }
    
    public override void LoadCargo(double weight)
    {
        if (weight > containerCapacity)
        {
            InfoHazard($"Overfill attempt on {serialNumber}");
            throw new OverfillException($"Can't load more than {containerCapacity}kg on {serialNumber}");
        }
        
        cargoWeight = weight;
    }

    public void InfoHazard(string message)
    {
        Console.WriteLine($"DANGEROUS - Gas: {message}");
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Pressure: {Pressure} atmospheres";
    }
}