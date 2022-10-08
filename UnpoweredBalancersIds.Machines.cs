using Mafi.Base;
using Mafi.Core.Factory.Machines;

namespace UnpoweredBalancers;

public partial class UnpoweredBalancersIds
{
    public partial class Machines
    {
        // Balancers
        public static readonly MachineProto.ID UnpoweredFlatBalancer = Ids.Machines.CreateId("UnpoweredFlatBalancer");
        public static readonly MachineProto.ID UnpoweredMoltenBalancer = Ids.Machines.CreateId("UnpoweredMoltenBalancer");
        public static readonly MachineProto.ID UnpoweredUShapeBalancer = Ids.Machines.CreateId("UnpoweredUShapeBalancer");
        public static readonly MachineProto.ID UnpoweredPipeBalancer = Ids.Machines.CreateId("UnpoweredPipeBalancer");
        // Sorters
        public static readonly MachineProto.ID UnpoweredFlatSorter = Ids.Machines.CreateId("UnpoweredFlatSorter");
        public static readonly MachineProto.ID UnpoweredUShapeSorter = Ids.Machines.CreateId("UnpoweredUShapeSorter");
    }
}
