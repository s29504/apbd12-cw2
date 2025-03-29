namespace zadanie1.Containers;

public class Container
{
    public double cargoWeight; //kg
    public double containerHeight; //cm
    public double containerWeight; //kg only container
    public double containerDepth; //cm
    public String serialNumber;  
    public Double containerCapacity;  //kg

    private static int serialCount = 1;

    public Container(double height, double weight, double depth,  char typeContainer, double capacity)
    {
        containerHeight = height;
        containerWeight = weight;
        containerDepth = depth;
        serialNumber = $"KON-{typeContainer}-{serialCount++}";
        containerCapacity = capacity;
    }

    public void Emptying()
    {
        cargoWeight = 0;
    }

    public virtual void LoadCargo(double weight)
    {
        if (weight > containerCapacity)
            throw new OverfillException($"Cannot load {weight}kg. Max: {containerCapacity}kg");
        cargoWeight = weight;
    }

    public override string ToString()
    {
        return
            $"{serialNumber}: Height={containerHeight}cm, Weight={containerWeight}kg, Depth={containerDepth}cm, Capacity={containerCapacity}kg, Load Weight={cargoWeight}kg";
    }
    
}