using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace UnpoweredBalancers;

internal class UnpoweredBalancersResearchData : IResearchNodesData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        ResearchNodeProto nodeProto = registrator.ResearchNodeProtoBuilder
            .Start("Research Unpowered balancers", UnpoweredBalancersIds.Research.UnlockUnpoweredBalancers)
            .Description("Unpowered balancers have the same function of normal balancers but they require no electricity to operate.")
            .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredFlatBalancer)
            .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredMoltenBalancer)
            .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredPipeBalancer)
            .AddMachineToUnlock(UnpoweredBalancersIds.Machines.UnpoweredUShapeBalancer)
            .BuildAndAdd();
        nodeProto.GridPosition = new Vector2i(4, 31);
        nodeProto.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.TransportsBalancing));
    }
}