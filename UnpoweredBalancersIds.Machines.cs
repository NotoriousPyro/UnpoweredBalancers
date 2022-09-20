using Mafi.Base;
using MachineID = Mafi.Core.Factory.Machines.MachineProto.ID;

namespace UnpoweredBalancers;

public partial class UnpoweredBalancersIds
{
	public partial class Machines
	{
		public static readonly MachineID UnpoweredFlatBalancer = Ids.Machines.CreateId("UnpoweredFlatBalancer");
		public static readonly MachineID UnpoweredMoltenBalancer = Ids.Machines.CreateId("UnpoweredMoltenBalancer");
		public static readonly MachineID UnpoweredUShapeBalancer = Ids.Machines.CreateId("UnpoweredUShapeBalancer");
		public static readonly MachineID UnpoweredPipeBalancer = Ids.Machines.CreateId("UnpoweredPipeBalancer");
	}

}