using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Computer;

public class Computer : IComputer
{
    public Computer(
        IMotherboard motherboard,
        IProcessor processor,
        IProcessorCoolingSystem processorCoolingSystem,
        IReadOnlyCollection<IRamMemory> ramMemories,
        IVideoCard? videoCard,
        IReadOnlyCollection<IExternalMemory> externalMemories,
        IPowerUnit powerUnit,
        IComputerCase computerCase,
        IWiFiAdapter? wiFiAdapter)
    {
        Motherboard = motherboard;
        Processor = processor;
        ProcessorCoolingSystem = processorCoolingSystem;
        RamMemories = ramMemories;
        VideoCard = videoCard;
        ExternalMemories = externalMemories;
        PowerUnit = powerUnit;
        ComputerCase = computerCase;
        WiFiAdapter = wiFiAdapter;
    }

    public IMotherboard Motherboard { get; }
    public IProcessor Processor { get; }
    public IProcessorCoolingSystem ProcessorCoolingSystem { get; }
    public IReadOnlyCollection<IRamMemory> RamMemories { get; }
    public IReadOnlyCollection<IExternalMemory> ExternalMemories { get; }
    public IPowerUnit PowerUnit { get; }
    public IComputerCase ComputerCase { get; }
    public IVideoCard? VideoCard { get; }
    public IWiFiAdapter? WiFiAdapter { get; }

    public IConfigurator Direct(IConfigurator configurator)
    {
        foreach (IRamMemory ramMemory in RamMemories)
            configurator.AddRamMemory(ramMemory);
        foreach (IExternalMemory externalMemory in ExternalMemories)
            configurator.AddExternalMemory(externalMemory);
        configurator.AddMotherboard(Motherboard);
        configurator.AddProcessor(Processor);
        configurator.AddProcessorCoolingSystem(ProcessorCoolingSystem);
        configurator.AddPowerUnitBuilder(PowerUnit);
        configurator.AddComputerCase(ComputerCase);
        if (VideoCard != null)
            configurator.AddVideoCard(VideoCard);
        if (WiFiAdapter != null)
            configurator.AddWiFiAdapter(WiFiAdapter);
        return configurator;
    }
}