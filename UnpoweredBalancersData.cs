using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Ports.Io;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using MachineID = Mafi.Core.Factory.Machines.MachineProto.ID;

namespace UnpoweredBalancers;

internal class UnpoweredBalancersData : IModData
{
	public void RegisterData(ProtoRegistrator registrator)
	{
		register(
			registrator,
			Ids.IoPortShapes.FlatConveyor,
			"Flat",
			UnpoweredBalancersIds.Machines.UnpoweredFlatBalancer,
			Assets.Base.Zippers.BalancerFlat_prefab,
			Costs.Build.CP3(6)
		);
		register(
			registrator,
			Ids.IoPortShapes.MoltenMetalChannel,
			"Molten",
			UnpoweredBalancersIds.Machines.UnpoweredMoltenBalancer,
			Assets.Base.Zippers.BalancerMolten_prefab,
			Costs.Build.CP3(9)
		);
		register(
			registrator,
			Ids.IoPortShapes.LooseMaterialConveyor,
			"U-shape",
			UnpoweredBalancersIds.Machines.UnpoweredUShapeBalancer,
			Assets.Base.Zippers.BalancerUShape_prefab,
			Costs.Build.CP3(9)
		);
		register(
			registrator,
			Ids.IoPortShapes.Pipe,
			"Pipe",
			UnpoweredBalancersIds.Machines.UnpoweredPipeBalancer,
			Assets.Base.Zippers.BalancerFluid_prefab,
			Costs.Build.CP3(6)
		);
	}

	private static string[] setPortChar(char portChar, params string[] layout)
	{
		int i = 0;
		for (int num = layout.Length; i < num; i++)
		{
			layout[i] = layout[i].Replace('?', portChar);
		}
		return layout;
	}

	private void register(
		ProtoRegistrator registrator,
		IoPortShapeProto.ID portShape,
		string name,
		MachineID id,
		string prefab,
		EntityCostsTpl costs
	) => new ZipperProtoBuilder(registrator)
			.Start($"Unpowered {name} balancer", id)
			.Description($"Allows distributing and prioritizing products using any of its two input and output ports.")
			.SetCost(costs)
			.SetElectricityConsumption(Mafi.Electricity.Zero)
			.SetLayout(
				new EntityLayoutParams(null, useNewLayoutSyntax: true, null, portsCanOnlyConnectToTransports: true),
				setPortChar(registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(portShape).LayoutChar, "   D?+C?+   ", "E?+[1][1]+?B", "F?+[1][1]+?A", "   G?+H?+   ")
			)
			.SetCategories(Ids.ToolbarCategories.Transports)
			.SetPrefabPath(prefab)
			.BuildAndAdd();
}
