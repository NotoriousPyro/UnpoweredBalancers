using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace UnpoweredBalancers.Research;

internal class UnpoweredBalancersResearchData : IResearchNodesData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        var conveyorParent = registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.ConveyorBeltsT3);
        registrator.ResearchNodeProtoBuilder
            .Start("Unpowered balancers", UnpoweredBalancersIds.Research.UnlockUnpoweredBalancers)
                .Description("Unpowered balancers have the same function of normal balancers but they require no electricity to operate.")
                .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredFlatBalancer)
                .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredMoltenBalancer)
                .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredPipeBalancer)
                .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredUShapeBalancer)
                .SetGridPosition(conveyorParent.GridPosition + new Vector2i(4, 0))
                .AddParents(
                    registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.ConveyorBeltsT3),
                    registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.PipeTransportsT3)
                )
                .SetCosts(ResearchCostsTpl.Build.SetDifficulty(20))
            .BuildAndAdd();
    }
}
