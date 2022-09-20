using Mafi.Base;
using Mafi.Core.Research;
using ResNodeID = Mafi.Core.Research.ResearchNodeProto.ID;

namespace UnpoweredBalancers;

public partial class UnpoweredBalancersIds {

	public partial class Research {

		[ResearchCosts(difficulty: 25)]
		public static readonly ResNodeID UnlockUnpoweredBalancers = Ids.Research.CreateId("UnlockUnpoweredBalancers");

	}

}