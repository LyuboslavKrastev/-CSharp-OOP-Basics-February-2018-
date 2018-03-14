using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    private string mode;
    private double totalEnergyStored;
    private double totalMinedOre;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        mode = "Full";
        totalEnergyStored = 0;
        totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = harvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
      
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = providerFactory.CreateProvider(arguments);
            providers.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }
    public string Day()
    {
        var dayEnergyProvided = providers.Sum(p => p.EnergyOutput);
        totalEnergyStored += dayEnergyProvided;
        double harvestersEnergyRequiredPerDay, minedOrePerDay;
        
        if (mode == "Full")
        {
            harvestersEnergyRequiredPerDay = harvesters.Sum(h => h.EnergyRequirement);
            minedOrePerDay = harvesters.Sum(h => h.OreOutput);
        }
        else if (mode == "Half")
        {
            harvestersEnergyRequiredPerDay = harvesters.Sum(h => h.EnergyRequirement) * 0.6;
            minedOrePerDay = harvesters.Sum(h => h.OreOutput) * 0.5;
        }
        else
        {
            harvestersEnergyRequiredPerDay = 0;
            minedOrePerDay = 0;
        }

        if (totalEnergyStored >= harvestersEnergyRequiredPerDay)
        {
            totalMinedOre += minedOrePerDay;
            totalEnergyStored -= harvestersEnergyRequiredPerDay;
        }
        else
        {
            minedOrePerDay = 0;
        }

        return $"A day has passed." + Environment.NewLine +
        $"Energy Provided: {dayEnergyProvided}" + Environment.NewLine +
        $"Plumbus Ore Mined: {minedOrePerDay}";
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    } 

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        Unit unit = (Unit)harvesters.FirstOrDefault(h => h.Id == id) ?? providers.FirstOrDefault(p => p.Id == id);

        if (unit == null)
        {
            throw new ArgumentException($"No element found with id - {id}");
        }

        return unit.ToString();
        
    }
    public string ShutDown()
    {
        return $"System Shutdown" + Environment.NewLine +
                $"Total Energy Stored: {totalEnergyStored}" + Environment.NewLine +
                 $"Total Mined Plumbus Ore: {totalMinedOre}";
    }
}

