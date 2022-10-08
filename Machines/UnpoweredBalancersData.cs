using Mafi.Base;
using Mafi.Core;
using Mafi.Core.Mods;
using Mafi.Core.Ports.Io;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using Mafi.Core.Factory.Zippers;
using Mafi.Core.Factory.Machines;

namespace UnpoweredBalancers.Machines;

internal class UnpoweredBalancersData : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        ZipperProto flatZipperProto = registrator.PrototypesDb.GetZipperProto(Ids.IoPortShapes.FlatConveyor);
        ZipperProto moltenZipperProto = registrator.PrototypesDb.GetZipperProto(Ids.IoPortShapes.MoltenMetalChannel);
        ZipperProto uShapeZipperProto = registrator.PrototypesDb.GetZipperProto(Ids.IoPortShapes.LooseMaterialConveyor);
        ZipperProto pipeZipperProto = registrator.PrototypesDb.GetZipperProto(Ids.IoPortShapes.Pipe);

        register(
            registrator,
            Ids.IoPortShapes.FlatConveyor,
            UnpoweredBalancersIds.Machines.UnpoweredFlatBalancer,
            "Flat",
            Assets.Base.Zippers.BalancerFlat_prefab,
            flatZipperProto.Graphics.IconPath,
            Costs.Build.CP3(6)
        );
        register(
            registrator,
            Ids.IoPortShapes.MoltenMetalChannel,
            UnpoweredBalancersIds.Machines.UnpoweredMoltenBalancer,
            "Molten",
            Assets.Base.Zippers.BalancerMolten_prefab,
            moltenZipperProto.Graphics.IconPath,
            Costs.Build.CP3(9)
        );
        register(
            registrator,
            Ids.IoPortShapes.LooseMaterialConveyor,
            UnpoweredBalancersIds.Machines.UnpoweredUShapeBalancer,
            "U-shape",
            Assets.Base.Zippers.BalancerUShape_prefab,
            uShapeZipperProto.Graphics.IconPath,
            Costs.Build.CP3(9)
        );
        register(
            registrator,
            Ids.IoPortShapes.Pipe,
            UnpoweredBalancersIds.Machines.UnpoweredPipeBalancer,
            "Pipe",
            Assets.Base.Zippers.BalancerFluid_prefab,
            pipeZipperProto.Graphics.IconPath,
            Costs.Build.CP3(6)
        );
    }

    private void register(
        ProtoRegistrator registrator,
        IoPortShapeProto.ID portShape,
        MachineProto.ID id,
        string name,
        string prefab,
        string icon,
        EntityCostsTpl costs
    ) => registrator.ZipperProtoBuilder()
        .Start($"Unpowered {name} balancer", id)
            .Description($"Allows distributing and prioritizing products using any of its two input and output ports.")
            .SetCost(costs)
            .SetElectricityConsumption(Mafi.Electricity.Zero)
            .SetLayout(
                new EntityLayoutParams(null, useNewLayoutSyntax: true, null, portsCanOnlyConnectToTransports: true),
                Ports.SetLayout(registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(portShape).LayoutChar, "   D?+C?+   ", "E?+[1][1]+?B", "F?+[1][1]+?A", "   G?+H?+   ")
            )
            .SetCategories(Ids.ToolbarCategories.Transports)
            .SetPrefabPath(prefab)
            .SetCustomIconPath(icon)
        .BuildAndAdd();
}
