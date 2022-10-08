using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace UnpoweredBalancers.Research;

internal class UnpoweredSortersResearchData : IResearchNodesData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        var balancerParent = registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(UnpoweredBalancersIds.Research.UnlockUnpoweredBalancers);
        registrator.ResearchNodeProtoBuilder
            .Start("Unpowered sorters", UnpoweredBalancersIds.Research.UnlockUnpoweredSorters)
                .Description("Unpowered sorters have the same function of normal sorters but they require no electricity to operate.")
                .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredFlatSorter)
                .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredUShapeSorter)
                .SetGridPosition(balancerParent.GridPosition + new Vector2i(0, 4))
                .AddParents(balancerParent)
                .SetCosts(ResearchCostsTpl.Build.SetDifficulty(20))
            .BuildAndAdd();
    }
}
