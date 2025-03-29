using System.Net;

namespace zadanie1.Containers;

public class CoolingContainer : Container
{
    public string Product { get; }
    public double Temperature { get; }
    
    
    private Dictionary<string, double> limitTemp = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 },
    };
    
    public CoolingContainer(double containerHeight, double containerWeight, double containerDepth, char typeContainer, double containerCapacity, string product, double temperature) : base(containerHeight, containerWeight, containerDepth, 'C', containerCapacity)
    {
        if (!limitTemp.ContainsKey(product))
            throw new Exception($"Product {product} not found");
        
        Product = product;
        Temperature = temperature;
        
        if(temperature < limitTemp[product])
            throw new Exception($"Temperature too low for {product}. Needed temperature is {limitTemp[product]}");
    }
    
    public override void LoadCargo(double weight)
    {
        if(weight > containerCapacity)
            throw new OverfillException($"Can't load more than {containerCapacity} cargo");
        cargoWeight = weight;
    }

    public string ToString()
    {
        return base.ToString() + $", Product: {Product}, Temperature: {Temperature}C";
    }
}