using Mafi;
using Mafi.Base;
using Mafi.Core;
using Mafi.Core.Mods;

namespace UnpoweredBalancers;

public sealed class UnpoweredBalancers : DataOnlyMod
{
    // Name of this mod. It will be eventually shown to the player.
    public override string Name => Core.Name;

    // Version, currently unused.
    public override int Version => Core.VersionInt;

    // Mod constructor that lists mod dependencies as parameters.
    // This guarantee that all listed mods will be loaded before this mod.
    // It is a good idea to depend on both `Mafi.Core.CoreMod` and `Mafi.Base.BaseMod`.
    public UnpoweredBalancers(CoreMod coreMod, BaseMod baseMod)
    {
        // You can use Log class for logging. These will be written to the log file
        // and can be also displayed in the in-game console with command `also_log_to_console`.
        Core.LogWithVersion(Log.Info, "constructed");
    }

    public override void RegisterPrototypes(ProtoRegistrator registrator)
    {
        Core.LogWithVersion(Log.Info, "registering prototypes");
        registrator.RegisterData<Machines.UnpoweredBalancersData>();
        registrator.RegisterData<Machines.UnpoweredSortersData>();
        registrator.RegisterDataWithInterface<IResearchNodesData>();
    }

}
