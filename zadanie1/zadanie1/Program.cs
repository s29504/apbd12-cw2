


using zadanie1.Containers;

internal class Program
{
    public static void Main(string[] args)
    {
        // Tworzenie kontenerow
        LiquidContainer milkContainer = new LiquidContainer(250, 1000, 300, 'L', 2000, false); 
        LiquidContainer fuelContainer = new LiquidContainer(250, 1000, 300, 'L', 3000, true);  
        GasContainer heliumContainer = new GasContainer(200, 800, 250, 'G', 1500, 5.0);    
        CoolingContainer bananaContainer = new CoolingContainer(240, 950, 280, 'C', 1800, "Bananas", 14); 
        CoolingContainer meatContainer = new CoolingContainer(240, 950, 280, 'C', 1800, "Meat", -15);    
        
        //Lista kontenerow
        List<Container> newContainers = new List<Container>
        {
            new LiquidContainer(250, 900, 280, 'L', 1500, false),
            new CoolingContainer(240, 950, 280, 'C', 1800, "Butter", 21)
        };
        
        // Zaladunek
        milkContainer.LoadCargo(1500);    
        fuelContainer.LoadCargo(1400);     
        heliumContainer.LoadCargo(1200);
        bananaContainer.LoadCargo(1700);  
        meatContainer.LoadCargo(1500);
        newContainers[0].LoadCargo(1200);
        newContainers[1].LoadCargo(1500);
        
        
        Ship ship1 = new Ship(30, 5, 20); 
        Ship ship2 = new Ship(25, 3, 15); 

        
        
        
        // Zaladunek na statek
        ship1.LoadContainer(milkContainer);
        ship1.LoadContainer(fuelContainer);
        ship1.LoadContainer(heliumContainer);
        ship1.LoadContainer(bananaContainer);
        ship1.LoadContainer(meatContainer);
        ship2.LoadContainers(newContainers);
        
        // Info o kontenerze
        Console.WriteLine("=== CONTAINER INFO ===");
        Console.WriteLine(heliumContainer.ToString());
        Console.WriteLine("=== CONTAINER INFO ===");
        Console.WriteLine(fuelContainer.ToString());
        
        // Info o statku
        ship1.PrintShipInfo();
        ship2.PrintShipInfo();

        
        // Rozladunek
        ship1.UnloadContainer(milkContainer.serialNumber);
        Console.WriteLine("\nMilk container unloaded.");

        // Usuniecie kontenera
        ship1.RemoveContainer(fuelContainer.serialNumber);
        Console.WriteLine("Fuel container removed.");

        // Zastapienie kontenera
        CoolingContainer cheeseContainer = new CoolingContainer(240, 950, 280, 'C', 1800, "Cheese", 8);
        cheeseContainer.LoadCargo(1600);
        ship1.ReplaceContainer(meatContainer.serialNumber, cheeseContainer);
        Console.WriteLine("Meat container replaced by cheese container.");

        // Przeniesienie kontenera miedzy statkami
        ship1.SwapContainer(ship2, heliumContainer.serialNumber);
        Console.WriteLine("Helium container moved to ship2.");

        
        Console.WriteLine("\n--- Ship 1 Final State ---");
        ship1.PrintShipInfo();

        Console.WriteLine("\n--- Ship 2 Final State ---");
        ship2.PrintShipInfo();

    }
}