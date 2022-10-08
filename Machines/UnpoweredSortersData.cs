using Mafi.Base;
using Mafi.Core.Products;
using Mafi.Core.Mods;
using Mafi.Core.Ports.Io;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using Mafi.Core.Factory.Sorters;
using Mafi.Core.Factory.Machines;

namespace UnpoweredBalancers.Machines;

internal class UnpoweredSortersData : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        SorterProto flatSorterProto = registrator.PrototypesDb.GetSorterProto(Ids.IoPortShapes.FlatConveyor);
        SorterProto uShapeSorterProto = registrator.PrototypesDb.GetSorterProto(Ids.IoPortShapes.LooseMaterialConveyor);

        register(
            registrator,
            Ids.IoPortShapes.FlatConveyor,
            UnpoweredBalancersIds.Machines.UnpoweredFlatSorter,
            CountableProductProto.ProductType,
            "Flat",
            Assets.Base.Zippers.SorterFlat_prefab,
            flatSorterProto.Graphics.IconPath,
            Costs.Build.CP3(6)
        );
        register(
            registrator,
            Ids.IoPortShapes.LooseMaterialConveyor,
            UnpoweredBalancersIds.Machines.UnpoweredUShapeSorter,
            LooseProductProto.ProductType,
            "U-shape",
            Assets.Base.Zippers.SorterUShape_prefab,
            uShapeSorterProto.Graphics.IconPath,
            Costs.Build.CP3(9)
        );
    }

    private void register(
        ProtoRegistrator registrator,
        IoPortShapeProto.ID portShape,
        MachineProto.ID id,
        ProductType productType,
        string name,
        string prefab,
        string icon,
        EntityCostsTpl costs
    ) => registrator.SorterProtoBuilder()
        .Start($"Unpowered {name} sorter", id)
            .Description($"Allows sorting of products.")
            .SetCost(costs)
            .SetElectricityConsumption(Mafi.Electricity.Zero)
            .SetLayout(
                new EntityLayoutParams(null, useNewLayoutSyntax: true),
                Ports.SetLayout(registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(portShape).LayoutChar, "A?>[1][1]>?X", "   [1][1]   ", "      v?S   ")
            )
            .SetCategories(Ids.ToolbarCategories.Transports)
            .SetProductsFilter(
                (ProductProto x) => x.Type == productType
            )
            .SetPrefabPath(prefab)
            .SetCustomIconPath(icon)
        .BuildAndAdd();
}


		
