using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WiFiAdapter : IWiFiAdapter
{
    private WiFiVersion _wiFiVersion;
    private PciEVersion _pciEVersion;

    public WiFiAdapter(WiFiVersion wiFiVersion, PciEVersion pciEVersion, CountType powerConsumptionV)
    {
        _wiFiVersion = wiFiVersion;
        _pciEVersion = pciEVersion;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType PowerConsumptionV { get; }

    public bool IsWiFiCompatibility(IMotherboard motherboard)
    {
        if (motherboard is IMotherboardWithWiFiModule)
            return false;
        return true;
    }

    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder wiFiAdapterBuilder)
    {
        wiFiAdapterBuilder.AddWiFiVersion(_wiFiVersion);
        wiFiAdapterBuilder.AddPciEVersion(_pciEVersion);
        wiFiAdapterBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return wiFiAdapterBuilder;
    }
}